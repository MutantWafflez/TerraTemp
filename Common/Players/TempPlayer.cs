﻿using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TerraTemp.Content.Buffs.TempEffects;
using TerraTemp.Content.Changes;
using TerraTemp.Content.Items.Accessories;
using TerraTemp.ID;
using TerraTemp.Utilities;

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
        /// The player's current biome, influencing the current environment temperature.
        /// </summary>
        public Climate currentBiome;

        /// <summary>
        /// The player's current evil biome, influencing the current environment temperature on top
        /// of the current biome.
        /// </summary>
        public EvilClimate currentEvilBiome;

        public override void ResetEffects() {
            baseDesiredTemperature = NormalTemperature;
            modifiedDesiredTemperature = baseDesiredTemperature;
            temperatureChangeResist = 0f;
            comfortableHigh = 30f;
            comfortableLow = 10f;
            relativeHumidity = 0f;
            criticalRangeMaximum = 10f;
            climateExtremityValue = 1f;
        }

        #region Update Overrides

        //Reset Temperature upon death
        public override void UpdateDead() {
            currentTemperature = NormalTemperature;
        }

        public override void PostUpdateMiscEffects() {
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

            //Updating the player's current evil biome
            foreach (EvilClimate biome in TerraTemp.evilClimates) {
                if (biome.EvilZoneBool(player)) {
                    currentEvilBiome = biome;
                    break;
                }
                //Current evil biome being null means the player is not in any evil biome, thus no change
                if (!biome.EvilZoneBool(player) && biome == TerraTemp.evilClimates.Last()) {
                    currentEvilBiome = null;
                    break;
                }
            }

            //Apply Tile Adjacency changes on player
            foreach (AdjacencyChange adjacencyChange in TerraTemp.adjacencyChanges) {
                if (adjacencyChange.CheckForAdjacency(player)) {
                    baseDesiredTemperature += adjacencyChange.DesiredTemperatureChange;
                    comfortableHigh += adjacencyChange.HeatComfortabilityChange;
                    comfortableLow += adjacencyChange.ColdComfortabilityChange;
                    temperatureChangeResist += adjacencyChange.TemperatureResistanceChange;
                    criticalRangeMaximum += adjacencyChange.CriticalTemperatureChange;
                }
            }

            //Apply Event changes on player
            foreach (EventChange change in TerraTemp.eventChanges) {
                if (change.EventBoolean && change.ApplyEventEffects(player)) {
                    baseDesiredTemperature += change.DesiredTemperatureChange;
                    comfortableHigh += change.HeatComfortabilityChange;
                    comfortableLow += change.ColdComfortabilityChange;
                    relativeHumidity += change.HumidityChange;
                    temperatureChangeResist += change.TemperatureResistanceChange;
                    criticalRangeMaximum += change.CriticalTemperatureChange;
                }
            }

            //Change desired temp & temperature resistance depending on the current biome, if applicable
            if (currentBiome != null) {
                baseDesiredTemperature += currentBiome.TemperatureModification * climateExtremityValue;
                temperatureChangeResist += currentBiome.TemperatureResistanceModification;
                relativeHumidity += currentBiome.HumidityModification;
            }
            //Change desired temp & temperature resistance depending on the current evil biome, if applicable
            if (currentEvilBiome != null) {
                baseDesiredTemperature += currentEvilBiome.TemperatureModification * climateExtremityValue;
                temperatureChangeResist += currentEvilBiome.TemperatureResistanceModification;
                relativeHumidity += currentEvilBiome.HumidityModification;
            }

            //Change desired temp based on what time of day it is and the daily temperature devation
            //Day will be hottest at Noon, the night will be coldest at Midnight
            if (player.ZoneOverworldHeight) {
                if (Main.dayTime && !Main.eclipse) {
                    if (Main.time <= 27000 /* Noon */) {
                        baseDesiredTemperature += ((float)Main.time / 60f / 50f * TerraTemp.dailyTemperatureDeviation) * TempUtilities.GetCloudEffectsOnSunTemperature();
                    }
                    else {
                        baseDesiredTemperature += ((54000f - (float)Main.time) / 60f / 50f * TerraTemp.dailyTemperatureDeviation) * TempUtilities.GetCloudEffectsOnSunTemperature();
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

            //Simply adding the Daily Humidity Deviation to player values.
            relativeHumidity += TerraTemp.dailyHumidityDeviation;

            //Increase desired temperature if player is adjacent to lava without an obsidian rose or obsidian skin effect
            if (player.adjLava && !player.lavaWet && !player.lavaRose && !player.lavaImmune) {
                baseDesiredTemperature += 12.5f;
            }

            //Set desired temperature to the average temperature of lava in the real world if the player enters it without an active lava charm or obsidian rose
            if (player.lavaWet && player.lavaTime <= 0 && !player.lavaRose && !player.lavaImmune) {
                baseDesiredTemperature = 1125f;
            }

            //Relative Humidity cannot exceed 100%, since that is impossible in real life and wouldn't make sense in game.
            relativeHumidity = MathHelper.Clamp(relativeHumidity, 0f, 1f);
            //Temperatue Change resistance cannot exceed 100% (due to that causing the value to go backwards), and won't go below -100% for balancing purposes.
            temperatureChangeResist = MathHelper.Clamp(temperatureChangeResist, -1f, 1f);

            //In real life, there is a mathematical formula that can be used to determine what the air temperature "feels like" to a human (AKA apparent temperature) being by taking humidity/wind speed into account.
            modifiedDesiredTemperature = TempUtilities.CalculateApparentTemperature(baseDesiredTemperature, relativeHumidity, player.ZoneOverworldHeight ? Math.Abs(Main.windSpeed * 100f) * 0.44704f : 0f);
        }

        public override void PostUpdate() {
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

        #region Custom Methods

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

        #endregion Custom Methods
    }
}