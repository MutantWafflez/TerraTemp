using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TerraTemp.Common.Systems;
using TerraTemp.Content.Buffs.TempEffects;
using TerraTemp.Content.Changes;
using TerraTemp.Content.Items.Accessories;
using TerraTemp.Custom;
using TerraTemp.Custom.Enums;

namespace TerraTemp.Common.Players {

    /// <summary>
    /// Player class that handles the actual temperature of each player in the mod.
    /// </summary>
    public class TempPlayer : ModPlayer {
        //ALL Temperature in this mod USES CELSIUS!

        #region Temperature Fields

        /// <summary>
        /// Normal temperature, or completely average.
        /// </summary>
        public const float NormalTemperature = 20f;

        /// <summary>
        /// Player's current body temperature.
        /// </summary>
        public float currentTemperature = NormalTemperature;

        /// <summary>
        /// Desired temperature that is modified by biomes and debuffs that is further modified by
        /// humidity and wind chill, if applicable. AKA "Environmental Temperature"
        /// </summary>
        public float baseDesiredTemperature = NormalTemperature;

        /// <summary>
        /// The temperature that the player's body temperature will ACTUALLY move towards. This
        /// value is modified based on factors outside of buffs/biomes/etc. including humidity and
        /// wind speed.
        /// </summary>
        public float modifiedDesiredTemperature;

        /// <summary>
        /// Value that modifies how fast the player's body temperature will move towards the desired temperature.
        /// </summary>
        public float temperatureChangeResist;

        /// <summary>
        /// Range of heat that the player can sustain with no negative side effects.
        /// </summary>
        public float comfortableHigh; //Default 30f

        /// <summary>
        /// Range of cold that the player can sustain with no negative side effects.
        /// </summary>
        public float comfortableLow; //Default 10f

        /// <summary>
        /// The relative humidity of the player (or rather, the environment around them). Increases
        /// the rate of body temperature increase at higher temperatures, similar to real life
        /// humditidy's effect on humans. Cannot exceed 100% (1f)
        /// </summary>
        public float relativeHumidity; //Default 0f

        /// <summary>
        /// Absolute maximum value above/below the player's comfortable range before the player
        /// dies. For example, if this value is 10 degrees and the comfortable ranges are their
        /// defaults, the player will die at 0 and 40 degrees respectively.
        /// </summary>
        public float criticalRangeMaximum; //Default 10f

        /// <summary>
        /// How much more or less intense the temperature changes of EVERY biome will be. By
        /// default, it is 1f (100%, normal).
        /// </summary>
        public float climateExtremityValue; //Default 1f

        /// <summary>
        /// How much more or less intense the temperature influence of the sun will have. By
        /// default, it is 1f (100%, normal).
        /// </summary>
        public float sunExtremityValue; //Default 1f;

        /// <summary>
        /// The player's current biome, influencing the current environment temperature.
        /// </summary>
        public Climate currentBiome;

        /// <summary>
        /// The player's current evil biome, influencing the current environment temperature on top
        /// of the current biome.
        /// </summary>
        public EvilClimate currentEvilBiome;

        /// <summary>
        /// List of all of the currently equipped item changes to prevent the bonuses of accessories
        /// from stacking.
        /// </summary>
        public List<ItemChange> equippedItemChanges;

        #endregion

        #region Update Overrides

        public override void ResetEffects() {
            baseDesiredTemperature = NormalTemperature;
            modifiedDesiredTemperature = baseDesiredTemperature;
            temperatureChangeResist = 0f;
            comfortableHigh = 30f;
            comfortableLow = 10f;
            relativeHumidity = 0f;
            criticalRangeMaximum = 10f;
            climateExtremityValue = 1f;
            sunExtremityValue = 1f;

            equippedItemChanges = new List<ItemChange>();
        }

        public override void PostUpdateMiscEffects() {
            MidEnvironmentUpdateClimate();

            MidEnvironmentUpdateEvilClimate();

            MidEnvironmentUpdateEvents();

            MidEnvironmentUpdateTileAdjacency();

            MidEnvironmentUpdateItemHoldoutChanges();

            //Climate Extremity should not exceed 200% (because that would be way too overkill if even possible in the first place) and a floor of 45% so biomes always have SOME kind of effect.
            climateExtremityValue = MathHelper.Clamp(climateExtremityValue, 0.45f, 2f);

            MidEnvironmentUpdateApplyBiomeEffects();

            MidEnvironmentUpdateApplyEvilBiomeEffects();

            MidEnvironmentUpdateApplySunExtremityEffects();

            //Sun Extremity should not exceed 200% (because that would be way too overkill if even possible in the first place) and a floor of 0% so the sun doesn't somehow make it colder.
            sunExtremityValue = MathHelper.Clamp(sunExtremityValue, 0f, 2f);

            MidEnvironmentUpdateApplyTimeEffects();

            MidEnvironmentUpdateApplyDepthEffects();

            MidEnvironmentUpdateApplyLavaEffects();

            //Simply adding the Daily Humidity Deviation to player values.
            relativeHumidity += WeeklyTemperatureSystem.weeklyHumidityDeviations[0];

            //Relative Humidity cannot exceed 100%, since that is impossible in real life and wouldn't make sense in game.
            relativeHumidity = MathHelper.Clamp(relativeHumidity, 0f, 1f);
            //Temperatue Change resistance cannot exceed 100% (due to that causing the value to go backwards), and won't go below -100% for balancing purposes.
            temperatureChangeResist = MathHelper.Clamp(temperatureChangeResist, -1f, 1f);
        }

        public override void PostUpdate() {
            bool isAffectedByWind = Player.ZoneOverworldHeight && !Player.IsIndoors();

            //In certain circumstances, the speed of the wind can cause an unholy level of cold that doesn't quite align with real life. Thus, the wind's effects will have a maximum potency that 45 mph winds have.
            float clampedWindSpeed = MathHelper.Clamp(Main.windSpeedCurrent, -0.45f, 0.45f);

            //In real life, there is a mathematical formula that can be used to determine what the air temperature "feels like" to a human (AKA apparent temperature) being by taking humidity/wind speed into account.
            modifiedDesiredTemperature = TempUtilities.CalculateApparentTemperature(baseDesiredTemperature, relativeHumidity, isAffectedByWind ? Math.Abs(clampedWindSpeed * 100f) * 0.44704f : 0f);

            //Body temperature will change at a rate equivalent to the difference between the body temperature and desired wet temperature
            // multiplied by the player's temperature change resistance.
            float difference = modifiedDesiredTemperature - currentTemperature;
            currentTemperature += difference / 60f / 45f * (1f - temperatureChangeResist);

            CheckForTemperatureEffects();
        }

        //Reset Temperature upon death
        public override void UpdateDead() {
            currentTemperature = NormalTemperature;
        }

        #endregion Update Overrides

        #region Draw Overrides

        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright) {
            //Heat visuals
            if (Player.HasBuff(ModContent.BuffType<Sweaty>())) {
                r = 1f;
                g = 189f / 255f;
                b = 189 / 255f;

                if (Main.rand.NextFloat() < 0.15f) {
                    //Adapted Vanilla Code for Dripping water
                    bool largerDroplets = Main.rand.NextBool();
                    Vector2 modifiedPosition = new Vector2(drawInfo.Position.X - 2f, drawInfo.Position.Y - 2f);
                    Dust water = Dust.NewDustDirect(modifiedPosition, largerDroplets ? Player.width + 8 : Player.width + 4, largerDroplets ? Player.height + 8 : Player.height + 2, 211, 0f, 0f, 50, default, largerDroplets ? 1.1f : 0.8f);
                    water.alpha += 25 * Main.rand.Next(0, 3);
                    water.noLight = true;
                    water.velocity.Y += largerDroplets ? 1f : 0.2f;
                    water.velocity += Player.velocity;
                    water.velocity *= 0.05f;
                }
            }
            if (Player.HasBuff(ModContent.BuffType<HeatStroke>())) {
                r = 1f;
                g = 150f / 255f;
                b = 150f / 255f;
            }
            //Cold visuals
            if (Player.HasBuff(ModContent.BuffType<Shivering>())) {
                r = 190f / 255f;
                g = 1f;
                b = 1f;
            }
            if (Player.HasBuff(ModContent.BuffType<Hypothermia>())) {
                r = 160f / 255f;
                g = 1f;
                b = 1f;
            }
        }

        #endregion

        #region I/O

        //Saving/Loading Temperature
        public override TagCompound Save() {
            return new TagCompound {
                {"currentTemp", currentTemperature},
            };
        }

        public override void Load(TagCompound tag) {
            currentTemperature = tag.GetFloat("currentTemp");
        }

        #endregion I/O

        #region Multiplayer Syncing

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer) {
            //Upon a new player joining the server, they'll need to have their "Deviation" values synced to match with the server. That is handled here:
            if (newPlayer) {
                ModPacket packet = Mod.GetPacket();
                packet.Write((byte)PacketID.RequestServerTemperatureValues);
                packet.Send();
            }
        }

        #endregion

        #region Environment Temperature Methods

        /// <summary>
        /// Method in the "Environment Update" process that takes place in <see
        /// cref="PostUpdateMiscEffects"/>. Updates the current player's biome, if it is all
        /// applicable. This is the first task in the Environment Update process. For the next task
        /// in the process, see <see cref="MidEnvironmentUpdateEvilClimate"/>.
        /// </summary>
        public void MidEnvironmentUpdateClimate() {
            //Updating the player's current biome
            foreach (Climate biome in TerraTemp.climates) {
                if (biome.PlayerZoneBool(Player)) {
                    currentBiome = biome;
                    break;
                }
                //Current biome being null means the player is in Forest, the default biome
                if (!biome.PlayerZoneBool(Player) && biome == TerraTemp.climates.Last()) {
                    currentBiome = null;
                    break;
                }
            }
        }

        /// <summary>
        /// Method in the "Environment Update" process that takes place in <see
        /// cref="PostUpdateMiscEffects"/>. Updates the current player's evil biome, if it is all
        /// applicable. This task is run immediately after <see
        /// cref="MidEnvironmentUpdateClimate"/>. For the next task in the process, see <see cref="MidEnvironmentUpdateEvents"/>.
        /// </summary>
        public void MidEnvironmentUpdateEvilClimate() {
            //Updating the player's current evil biome
            foreach (EvilClimate evilBiome in TerraTemp.evilClimates) {
                if (evilBiome.EvilZoneBool(Player)) {
                    currentEvilBiome = evilBiome;
                    break;
                }
                //Current evil biome being null means the player is not in any evil biome, thus no change
                if (!evilBiome.EvilZoneBool(Player) && evilBiome == TerraTemp.evilClimates.Last()) {
                    currentEvilBiome = null;
                    break;
                }
            }
        }

        /// <summary>
        /// Method in the "Environment Update" process that takes place in <see
        /// cref="PostUpdateMiscEffects"/>. Applies the effects of any events currently taking
        /// place, if it is all applicable. This task is run immediately after <see
        /// cref="MidEnvironmentUpdateEvilClimate"/>. For the next task in the process, see <see cref="MidEnvironmentUpdateTileAdjacency"/>.
        /// </summary>
        public void MidEnvironmentUpdateEvents() {
            //Apply Event changes on player
            foreach (EventChange eventChange in TerraTemp.eventChanges) {
                if (eventChange.EventBoolean && eventChange.ApplyEventEffects(Player)) {
                    TempUtilities.ApplyStatChanges(eventChange, Player);
                }
            }
        }

        /// <summary>
        /// Method in the "Environment Update" process that takes place in <see
        /// cref="PostUpdateMiscEffects"/>. Applies the effects of any tiles that affect
        /// temperature, if it is all applicable. This task is run immediately after <see
        /// cref="MidEnvironmentUpdateEvents"/>. For the next task in the process, see <see cref="MidEnvironmentUpdateItemHoldoutChanges"/>.
        /// </summary>
        public void MidEnvironmentUpdateTileAdjacency() {
            //Apply Tile Adjacency changes on player
            foreach (AdjacencyChange adjacencyChange in TerraTemp.adjacencyChanges) {
                if (adjacencyChange.CheckForAdjacency(Player)) {
                    TempUtilities.ApplyStatChanges(adjacencyChange, Player);
                }
            }
        }

        /// <summary>
        /// Method in the "Environment Update" process that takes place in <see
        /// cref="PostUpdateMiscEffects"/>. Applies the effects of any potential items that have an
        /// effect when holding them in the player's hand. This task is run immediately after <see
        /// cref="MidEnvironmentUpdateTileAdjacency"/>. For the next task in the process, see <see cref="MidEnvironmentUpdateApplyBiomeEffects"/>.
        /// </summary>
        public void MidEnvironmentUpdateItemHoldoutChanges() {
            //This item holdout change must be handled here since the HeldItem() method in Global Items are called too late in the update process.
            foreach (ItemHoldoutChange itemHoldoutChange in TerraTemp.itemHoldoutChanges) {
                if (itemHoldoutChange.AppliedItemIDs.Contains(Player.HeldItem.type)) {
                    TempUtilities.ApplyStatChanges(itemHoldoutChange, Player);
                    itemHoldoutChange.AdditionalItemHoldoutEffect(Player);
                }
            }
        }

        /// <summary>
        /// Method in the "Environment Update" process that takes place in <see
        /// cref="PostUpdateMiscEffects"/>. Applies the current effects of the biome that the player
        /// is in, if it is all applicable. This task is run immediately after <see
        /// cref="MidEnvironmentUpdateItemHoldoutChanges"/>. For the next task in the process, see
        /// <see cref="MidEnvironmentUpdateApplyEvilBiomeEffects"/>.
        /// </summary>
        public void MidEnvironmentUpdateApplyBiomeEffects() {
            //Change desired temp & temperature resistance depending on the current biome, if applicable
            if (currentBiome != null) {
                baseDesiredTemperature += (currentBiome.GetDesiredTemperatureChange(Player) + (Player.wet ? currentBiome.WaterTemperature : 0f)) * climateExtremityValue;
                relativeHumidity += currentBiome.GetHumidityChange(Player);
                comfortableHigh += currentBiome.GetHeatComfortabilityChange(Player);
                comfortableLow += currentBiome.GetColdComfortabilityChange(Player);
                temperatureChangeResist += currentBiome.GetTemperatureResistanceChange(Player);
                criticalRangeMaximum += currentBiome.GetCriticalTemperatureChange(Player);
                climateExtremityValue += currentBiome.GetClimateExtremityChange(Player);
            }
        }

        /// <summary>
        /// Method in the "Environment Update" process that takes place in <see
        /// cref="PostUpdateMiscEffects"/>. Applies the current effects of the evil biome that the
        /// player is in, if it is all applicable. This task is run immediately after <see
        /// cref="MidEnvironmentUpdateApplyBiomeEffects"/>. For the next task in the process, see
        /// <see cref="MidEnvironmentUpdateApplySunExtremityEffects"/>.
        /// </summary>
        public void MidEnvironmentUpdateApplyEvilBiomeEffects() {
            //Change desired temp & temperature resistance depending on the current evil biome, if applicable
            if (currentEvilBiome != null) {
                baseDesiredTemperature += (currentEvilBiome.GetDesiredTemperatureChange(Player) + (Player.wet ? currentEvilBiome.WaterTemperature : 0f)) * climateExtremityValue;
                relativeHumidity += currentEvilBiome.GetHumidityChange(Player);
                comfortableHigh += currentEvilBiome.GetHeatComfortabilityChange(Player);
                comfortableLow += currentEvilBiome.GetColdComfortabilityChange(Player);
                temperatureChangeResist += currentEvilBiome.GetTemperatureResistanceChange(Player);
                criticalRangeMaximum += currentEvilBiome.GetCriticalTemperatureChange(Player);
                climateExtremityValue += currentEvilBiome.GetClimateExtremityChange(Player);
            }
        }

        /// <summary> Method in the "Environment Update" process that takes place in <see
        /// cref="PostUpdateMiscEffects"/>. Applies external factors that influence the temperature
        /// increase of the sun (such as Cloud influence & Shade influnece). This task is run
        /// immediately after <see cref="MidEnvironmentUpdateApplyEvilBiomeEffects"/>. For the next
        /// task in the process, see <see cref="MidEnvironmentUpdateApplyTimeEffects"/>. </summary>
        public void MidEnvironmentUpdateApplySunExtremityEffects() {
            sunExtremityValue *= WeeklyTemperatureSystem.weeklyTemperatureDeviations[0];
            sunExtremityValue *= TempUtilities.GetCloudEffectsOnSunTemperature();
            sunExtremityValue *= TempUtilities.GetShadeEffectsOnSunTemperature(Player);
        }

        /// <summary>
        /// Method in the "Environment Update" process that takes place in <see
        /// cref="PostUpdateMiscEffects"/>. Applies the current effects of the time of day if the
        /// player is on the surface. This task is run immediately after <see
        /// cref="MidEnvironmentUpdateApplySunExtremityEffects"/>. For the next task in the process,
        /// see <see cref="MidEnvironmentUpdateApplyDepthEffects"/>.
        /// </summary>
        public void MidEnvironmentUpdateApplyTimeEffects() {
            //Change desired temp based on what time of day it is and the daily temperature devation
            //Day will be hottest at Noon, the night will be coldest at Midnight
            if (Player.ZoneOverworldHeight) {
                if (Main.dayTime && !Main.eclipse) {
                    if (Main.time <= 27000 /* Noon */) {
                        baseDesiredTemperature += ((float)Main.time / 60f / 50f) * sunExtremityValue;
                    }
                    else {
                        baseDesiredTemperature += ((54000f - (float)Main.time) / 60f / 50f) * sunExtremityValue;
                    }
                }
                else {
                    if (Main.time <= 16200 /* Midnight */) {
                        baseDesiredTemperature -= (float)Main.time / 60f / 30f * WeeklyTemperatureSystem.weeklyTemperatureDeviations[0];
                    }
                    else {
                        baseDesiredTemperature -= (32400f - (float)Main.time) / 60f / 30f * WeeklyTemperatureSystem.weeklyTemperatureDeviations[0];
                    }
                }
            }
        }

        /// <summary>
        /// Method in the "Environment Update" process that takes place in <see
        /// cref="PostUpdateMiscEffects"/>. Applies the effects of the player's depth if they are
        /// underground. This task is run immediately after <see
        /// cref="MidEnvironmentUpdateApplyTimeEffects"/>. For the next task in the process, see
        /// <see cref="MidEnvironmentUpdateApplyLavaEffects"/>.
        /// </summary>
        public void MidEnvironmentUpdateApplyDepthEffects() {
            //If player is not within the bottom third of the map and not in the underworld, apply depth influence.
            if (Player.Center.ToTileCoordinates().Y < Main.maxTilesY - (Main.maxTilesY / 3f) && !Player.ZoneUnderworldHeight) {
                if (Player.ZoneDirtLayerHeight) {
                    baseDesiredTemperature -= 3f;
                }
                else if (Player.ZoneRockLayerHeight) {
                    baseDesiredTemperature -= 5f;
                }
            }
        }

        /// <summary>
        /// Method in the "Environment Update" process that takes place in <see
        /// cref="PostUpdateMiscEffects"/>. Applies the effects of Lava if the player is adjacent to
        /// it or in it. This task is run immediately after <see
        /// cref="MidEnvironmentUpdateApplyDepthEffects"/>. This is the last task in the
        /// "Environment Update" process.
        /// </summary>
        public void MidEnvironmentUpdateApplyLavaEffects() {
            //Increase desired temperature if player is adjacent to lava without an obsidian rose or obsidian skin effect
            if (Player.adjLava && !Player.lavaWet && !Player.lavaRose && !Player.lavaImmune) {
                baseDesiredTemperature += 12.5f;
            }

            //Set desired temperature to the average temperature of lava in the real world if the player enters it without an active lava charm or obsidian rose
            if (Player.lavaWet && Player.lavaTime <= 0 && !Player.lavaRose && !Player.lavaImmune) {
                baseDesiredTemperature = 1125f;
            }
        }

        #endregion Environment Temperature Methods

        #region Miscellaneous Methods

        /// <summary> Method that checks & applies the effects of the player's current Body
        /// Temperature. </summary>
        public void CheckForTemperatureEffects() {
            //Heat Effects
            if (currentTemperature > comfortableHigh) {
                //Sweaty Effect
                Player.AddBuff(ModContent.BuffType<Sweaty>(), 5);
                //Heat Stroke
                if (currentTemperature > comfortableHigh + (criticalRangeMaximum / 2f) && currentTemperature < comfortableHigh + criticalRangeMaximum) {
                    Player.AddBuff(ModContent.BuffType<HeatStroke>(), 5);
                }
                //Death
                if (currentTemperature > comfortableHigh + criticalRangeMaximum) {
                    PlayerDeathReason deathReason = PlayerDeathReason.ByCustomReason(Player.name + " " + TempUtilities.GetTerraTempTextValue("DeathMessage.Heat." + Main.rand.Next(0, 20)));

                    Player.KillMe(deathReason, 9999, 0);
                }
            }
            //Cold Effects
            else if (currentTemperature < comfortableLow) {
                //Chilly Effect
                Player.AddBuff(ModContent.BuffType<Shivering>(), 5);
                //Hypothermia
                if (currentTemperature < comfortableLow - (criticalRangeMaximum / 2f) && currentTemperature > comfortableLow - criticalRangeMaximum) {
                    Player.AddBuff(ModContent.BuffType<Hypothermia>(), 5);
                }
                //Death
                if (currentTemperature < comfortableLow - criticalRangeMaximum) {
                    PlayerDeathReason deathReason = PlayerDeathReason.ByCustomReason(Player.name + " " + TempUtilities.GetTerraTempTextValue("DeathMessage.Cold." + Main.rand.Next(0, 20)));

                    Player.KillMe(deathReason, 9999, 0);
                }
            }
        }

        #endregion Miscellaneous Methods
    }
}