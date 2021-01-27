using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TerraTemp.Content.Buffs.TempEffects;
using TerraTemp.Content.Changes;
using TerraTemp.Content.Items.Accessories;
using TerraTemp.Content.ModChanges;
using TerraTemp.Custom;
using TerraTemp.Custom.Enums;

namespace TerraTemp {

    /// <summary>
    /// Player class that handles the actual temperature of each player in the mod.
    /// </summary>
    public class TempPlayer : ModPlayer {
        //ALL Temperature in this mod USES CELSIUS!

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
        /// The player's current mod biome, if available at all. Takes priority over any vanilla
        /// biome or evil biomes, as far as I know.
        /// </summary>
        public ModClimate currentModBiome;

        /// <summary>
        /// List of all of the currently equipped item changes to prevent the bonuses of accessories
        /// from stacking.
        /// </summary>
        public List<ItemChange> equippedItemChanges;

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

        #region Update Overrides

        //Reset Temperature upon death
        public override void UpdateDead() {
            currentTemperature = NormalTemperature;
        }

        public override void PostUpdateMiscEffects() {
            MidEnvironmentUpdateClimate();

            MidEnvironmentUpdateEvilClimate();

            MidEnvironmentUpdateModClimate();

            MidEnvironmentUpdateEvents();

            MidEnvironmentUpdateModEvents();

            MidEnvironmentUpdateTileAdjacency();

            MidEnvironmentUpdateItemHoldoutChanges();

            //Climate Extremity should not exceed 200% (because that would be way too overkill if even possible in the first place) and a floor of 45% so biomes always have SOME kind of effect.
            climateExtremityValue = MathHelper.Clamp(climateExtremityValue, 0.45f, 2f);

            MidEnvironmentUpdateApplyBiomeEffects();

            MidEnvironmentUpdateApplyEvilBiomeEffects();

            MidEnvironmentUpdateApplyModBiomeEffects();

            MidEnvironmentUpdateApplySunExtremityEffects();

            //Sun Exremity should not exceed 200% (because that would be way too overkill if even possible in the first place) and a floor of 0% so the sun doesn't somehow make it colder.
            sunExtremityValue = MathHelper.Clamp(sunExtremityValue, 0f, 2f);

            MidEnvironmentUpdateApplyTimeEffects();

            MidEnvironmentUpdateApplyDepthEffects();

            MidEnvironmentUpdateApplyLavaEffects();

            //Simply adding the Daily Humidity Deviation to player values.
            relativeHumidity += TerraTemp.dailyHumidityDeviation;

            //Relative Humidity cannot exceed 100%, since that is impossible in real life and wouldn't make sense in game.
            relativeHumidity = MathHelper.Clamp(relativeHumidity, 0f, 1f);
            //Temperatue Change resistance cannot exceed 100% (due to that causing the value to go backwards), and won't go below -100% for balancing purposes.
            temperatureChangeResist = MathHelper.Clamp(temperatureChangeResist, -1f, 1f);
        }

        public override void PostUpdate() {
            bool isAffectedByWind = player.ZoneOverworldHeight && !(player.IsUnderRoof() && player.behindBackWall);
            //In real life, there is a mathematical formula that can be used to determine what the air temperature "feels like" to a human (AKA apparent temperature) being by taking humidity/wind speed into account.
            modifiedDesiredTemperature = TempUtilities.CalculateApparentTemperature(baseDesiredTemperature, relativeHumidity, isAffectedByWind ? Math.Abs(Main.windSpeed * 100f) * 0.44704f : 0f);

            //Body temperature will change at a rate equivalent to the difference between the body temperature and desired wet temperature
            // multiplied by the player's temperature change resistance.
            float difference = modifiedDesiredTemperature - currentTemperature;
            currentTemperature += difference / 60f / 45f * (1f - temperatureChangeResist);

            CheckForTemperatureEffects();
        }

        #endregion Update Overrides

        #region Draw Overrides

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright) {
            //Heat visuals
            if (player.HasBuff(ModContent.BuffType<Sweaty>())) {
                r = 1f;
                g = 189f / 255f;
                b = 189 / 255f;

                if (Main.rand.NextFloat() < 0.15f) {
                    //Adapted Vanilla Code for Dripping water
                    bool largerDroplets = Main.rand.NextBool();
                    Vector2 modifiedPosition = new Vector2(drawInfo.position.X - 2f, drawInfo.position.Y - 2f);
                    Dust water = Dust.NewDustDirect(modifiedPosition, largerDroplets ? player.width + 8 : player.width + 4, largerDroplets ? player.height + 8 : player.height + 2, 211, 0f, 0f, 50, default, largerDroplets ? 1.1f : 0.8f);
                    water.alpha += 25 * Main.rand.Next(0, 3);
                    water.noLight = true;
                    water.velocity.Y += largerDroplets ? 1f : 0.2f;
                    water.velocity += player.velocity;
                    water.velocity *= 0.05f;
                    Main.playerDrawDust.Add(water.dustIndex);
                }
            }
            if (player.HasBuff(ModContent.BuffType<HeatStroke>())) {
                r = 1f;
                g = 150f / 255f;
                b = 150f / 255f;
            }
            //Cold visuals
            if (player.HasBuff(ModContent.BuffType<Shivering>())) {
                r = 190f / 255f;
                g = 1f;
                b = 1f;
            }
            if (player.HasBuff(ModContent.BuffType<Hypothermia>())) {
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
                ModPacket packet = mod.GetPacket();
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
                if (biome.PlayerZoneBool(player)) {
                    currentBiome = biome;
                    break;
                }
                //Current biome being null means the player is in Forest, the default biome
                if (!biome.PlayerZoneBool(player) && biome == TerraTemp.climates.Last()) {
                    currentBiome = null;
                    break;
                }
            }
        }

        /// <summary>
        /// Method in the "Environment Update" process that takes place in <see
        /// cref="PostUpdateMiscEffects"/>. Updates the current player's evil biome, if it is all
        /// applicable. This task is run immediately after <see
        /// cref="MidEnvironmentUpdateClimate"/>. For the next task in the process, see <see cref="MidEnvironmentUpdateModClimate"/>.
        /// </summary>
        public void MidEnvironmentUpdateEvilClimate() {
            //Updating the player's current evil biome
            foreach (EvilClimate evilBiome in TerraTemp.evilClimates) {
                if (evilBiome.EvilZoneBool(player)) {
                    currentEvilBiome = evilBiome;
                    break;
                }
                //Current evil biome being null means the player is not in any evil biome, thus no change
                if (!evilBiome.EvilZoneBool(player) && evilBiome == TerraTemp.evilClimates.Last()) {
                    currentEvilBiome = null;
                    break;
                }
            }
        }

        /// <summary>
        /// Method in the "Environment Update" process that takes place in <see
        /// cref="PostUpdateMiscEffects"/>. Updates the current player's mod biome, if it is all
        /// applicable. This task is run immediately after <see
        /// cref="MidEnvironmentUpdateEvilClimate"/>. For the next task in the process, see <see cref="MidEnvironmentUpdateEvents"/>.
        /// </summary>
        public void MidEnvironmentUpdateModClimate() {
            //Updating the player's current modded biome
            foreach (ModClimate modClimate in TerraTemp.modClimates) {
                if (modClimate.IsPlayerInBiome(player)) {
                    currentModBiome = modClimate;
                    break;
                }
                //Current mod biome being null means the player is not in any mod biome, thus no change
                if (!modClimate.IsPlayerInBiome(player) && modClimate == TerraTemp.modClimates.Last()) {
                    currentModBiome = null;
                }
            }
        }

        /// <summary>
        /// Method in the "Environment Update" process that takes place in <see
        /// cref="PostUpdateMiscEffects"/>. Applies the effects of any events currently taking
        /// place, if it is all applicable. This task is run immediately after <see
        /// cref="MidEnvironmentUpdateModClimate"/>. For the next task in the process, see <see cref="MidEnvironmentUpdateModEvents"/>.
        /// </summary>
        public void MidEnvironmentUpdateEvents() {
            //Apply Event changes on player
            foreach (EventChange eventChange in TerraTemp.eventChanges) {
                if (eventChange.EventBoolean && eventChange.ApplyEventEffects(player)) {
                    TempUtilities.ApplyStatChanges(eventChange, player);
                }
            }
        }

        /// <summary>
        /// Method in the "Environment Update" process that takes place in <see
        /// cref="PostUpdateMiscEffects"/>. Applies the effects of any compatible mod events
        /// currently taking place, if it is all applicable. This task is run immediately after <see
        /// cref="MidEnvironmentUpdateEvents"/>. For the next task in the process, see <see cref="MidEnvironmentUpdateTileAdjacency"/>.
        /// </summary>
        public void MidEnvironmentUpdateModEvents() {
            //Apply any possible Modded Event changes on player
            foreach (ModEvent modEvent in TerraTemp.modEvents) {
                if (modEvent.ApplyEventEffects(player)) {
                    TempUtilities.ApplyStatChanges(modEvent, player);
                }
            }
        }

        /// <summary>
        /// Method in the "Environment Update" process that takes place in <see
        /// cref="PostUpdateMiscEffects"/>. Applies the effects of any tiles that affect
        /// temperature, if it is all applicable. This task is run immediately after <see
        /// cref="MidEnvironmentUpdateModEvents"/>. For the next task in the process, see <see cref="MidEnvironmentUpdateItemHoldoutChanges"/>.
        /// </summary>
        public void MidEnvironmentUpdateTileAdjacency() {
            //Apply Tile Adjacency changes on player
            foreach (AdjacencyChange adjacencyChange in TerraTemp.adjacencyChanges) {
                if (adjacencyChange.CheckForAdjacency(player)) {
                    TempUtilities.ApplyStatChanges(adjacencyChange, player);
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
                if (itemHoldoutChange.AppliedItemIDs.Contains(player.HeldItem.type)) {
                    TempUtilities.ApplyStatChanges(itemHoldoutChange, player);
                    itemHoldoutChange.AdditionalItemHoldoutEffect(player);
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
                baseDesiredTemperature += (currentBiome.GetDesiredTemperatureChange(player) + (player.wet ? currentBiome.WaterTemperature : 0f)) * climateExtremityValue;
                relativeHumidity += currentBiome.GetHumidityChange(player);
                comfortableHigh += currentBiome.GetHeatComfortabilityChange(player);
                comfortableLow += currentBiome.GetColdComfortabilityChange(player);
                temperatureChangeResist += currentBiome.GetTemperatureResistanceChange(player);
                criticalRangeMaximum += currentBiome.GetCriticalTemperatureChange(player);
                climateExtremityValue += currentBiome.GetClimateExtremityChange(player);
            }
        }

        /// <summary>
        /// Method in the "Environment Update" process that takes place in <see
        /// cref="PostUpdateMiscEffects"/>. Applies the current effects of the evil biome that the
        /// player is in, if it is all applicable. This task is run immediately after <see
        /// cref="MidEnvironmentUpdateApplyBiomeEffects"/>. For the next task in the process, see
        /// <see cref="MidEnvironmentUpdateApplyModBiomeEffects"/>.
        /// </summary>
        public void MidEnvironmentUpdateApplyEvilBiomeEffects() {
            //Change desired temp & temperature resistance depending on the current evil biome, if applicable
            if (currentEvilBiome != null) {
                baseDesiredTemperature += (currentEvilBiome.GetDesiredTemperatureChange(player) + (player.wet ? currentEvilBiome.WaterTemperature : 0f)) * climateExtremityValue;
                relativeHumidity += currentEvilBiome.GetHumidityChange(player);
                comfortableHigh += currentEvilBiome.GetHeatComfortabilityChange(player);
                comfortableLow += currentEvilBiome.GetColdComfortabilityChange(player);
                temperatureChangeResist += currentEvilBiome.GetTemperatureResistanceChange(player);
                criticalRangeMaximum += currentEvilBiome.GetCriticalTemperatureChange(player);
                climateExtremityValue += currentEvilBiome.GetClimateExtremityChange(player);
            }
        }

        /// <summary>
        /// Method in the "Environment Update" process that takes place in <see
        /// cref="PostUpdateMiscEffects"/>. Applies the current effects of the mod biome that the
        /// player is in, if it is all applicable. This task is run immediately after <see
        /// cref="MidEnvironmentUpdateApplyEvilBiomeEffects"/>. For the next task in the process,
        /// see <see cref="MidEnvironmentUpdateApplySunExtremityEffects"/>.
        /// </summary>
        public void MidEnvironmentUpdateApplyModBiomeEffects() {
            //Change desired temp & temperature resistance depending on the current mod biome, if applicable
            if (currentModBiome != null) {
                baseDesiredTemperature += currentModBiome.GetDesiredTemperatureChange(player) * climateExtremityValue;
                relativeHumidity += currentModBiome.GetHumidityChange(player);
                comfortableHigh += currentModBiome.GetHeatComfortabilityChange(player);
                comfortableLow += currentModBiome.GetColdComfortabilityChange(player);
                temperatureChangeResist += currentModBiome.GetTemperatureResistanceChange(player);
                criticalRangeMaximum += currentModBiome.GetCriticalTemperatureChange(player);
                climateExtremityValue += currentModBiome.GetClimateExtremityChange(player);
            }
        }

        /// <summary> Method in the "Environment Update" process that takes place in <see
        /// cref="PostUpdateMiscEffects"/>. Applies external factors that influence the temperature
        /// increase of the sun (such as Cloud influence & Shade influnece). This task is run
        /// immediately after <see cref="MidEnvironmentUpdateApplyModBiomeEffects"/>. For the next
        /// task in the process, see <see cref="MidEnvironmentUpdateApplyTimeEffects"/>. </summary>
        public void MidEnvironmentUpdateApplySunExtremityEffects() {
            sunExtremityValue *= TerraTemp.dailyTemperatureDeviation;
            sunExtremityValue *= TempUtilities.GetCloudEffectsOnSunTemperature();
            sunExtremityValue *= TempUtilities.GetShadeEffectsOnSunTemperature(player);
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
            if (player.ZoneOverworldHeight) {
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
                        baseDesiredTemperature -= (float)Main.time / 60f / 30f * TerraTemp.dailyTemperatureDeviation;
                    }
                    else {
                        baseDesiredTemperature -= (32400f - (float)Main.time) / 60f / 30f * TerraTemp.dailyTemperatureDeviation;
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
            if (player.Center.ToTileCoordinates().Y < Main.maxTilesY - (Main.maxTilesY / 3f) && !player.ZoneUnderworldHeight) {
                if (player.ZoneDirtLayerHeight) {
                    baseDesiredTemperature -= 3f;
                }
                else if (player.ZoneRockLayerHeight) {
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
            if (player.adjLava && !player.lavaWet && !player.lavaRose && !player.lavaImmune) {
                baseDesiredTemperature += 12.5f;
            }

            //Set desired temperature to the average temperature of lava in the real world if the player enters it without an active lava charm or obsidian rose
            if (player.lavaWet && player.lavaTime <= 0 && !player.lavaRose && !player.lavaImmune) {
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
                player.AddBuff(ModContent.BuffType<Sweaty>(), 5);
                //Heat Stroke
                if (currentTemperature > comfortableHigh + (criticalRangeMaximum / 2f) && currentTemperature < comfortableHigh + criticalRangeMaximum) {
                    player.AddBuff(ModContent.BuffType<HeatStroke>(), 5);
                }
                //Death
                if (currentTemperature > comfortableHigh + criticalRangeMaximum) {
                    PlayerDeathReason deathReason = PlayerDeathReason.ByCustomReason(player.name + " " + TempUtilities.GetTerraTempTextValue("DeathMessage.Heat." + Main.rand.Next(0, 11)));
                    //For the Volatile Themometer effect to properly take place
                    deathReason.SourceItemType = ModContent.ItemType<VolatileThermometer>();
                    player.KillMe(deathReason, 9999, 0);
                }
            }
            //Cold Effects
            else if (currentTemperature < comfortableLow) {
                //Chilly Effect
                player.AddBuff(ModContent.BuffType<Shivering>(), 5);
                //Hypothermia
                if (currentTemperature < comfortableLow - (criticalRangeMaximum / 2f) && currentTemperature > comfortableLow - criticalRangeMaximum) {
                    player.AddBuff(ModContent.BuffType<Hypothermia>(), 5);
                }
                //Death
                if (currentTemperature < comfortableLow - criticalRangeMaximum) {
                    PlayerDeathReason deathReason = PlayerDeathReason.ByCustomReason(player.name + " " + TempUtilities.GetTerraTempTextValue("DeathMessage.Cold." + Main.rand.Next(0, 11)));
                    //For the Volatile Themometer effect to properly take place
                    deathReason.SourceItemType = ModContent.ItemType<VolatileThermometer>();
                    player.KillMe(deathReason, 9999, 0);
                }
            }
        }

        #endregion Miscellaneous Methods
    }
}