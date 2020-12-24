using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TerraTemp.Content.Buffs.TempEffects;
using TerraTemp.Utilities;

namespace TerraTemp {
    public class TempPlayer : ModPlayer {
        //ALL Temperature in this mod USES CELSIUS!

        /// <summary>
        /// Normal temperature, or completely average.
        /// </summary>
        public const float NormalTemperature = 20f;
        /// <summary>
        /// Player's current body temperature.
        /// </summary>
        public float currentTemperature;
        /// <summary>
        /// The temperature that the player's body temperature will move towards.
        /// </summary>
        public float desiredTemperature = NormalTemperature;
        /// <summary>
        /// Value that modifies  how fast the player's body temperature will move towards the desired temperature.
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
        /// Absolute maximum value above/below the player's comfortable range before the player dies.
        /// For example, if this value is 10 degrees and the comfortable ranges are their defaults, the player will die at 0 and 40 degrees respectively.
        /// </summary>
        public float criticalRangeMaximum; //Default 10f

        /// <summary>
        /// The player's current biome, influencing the current environment temperature.
        /// </summary>
        public TempBiome currentBiome;
        /// <summary>
        /// The player's current evil biome, influencing the current environment temperature on top of the current biome.
        /// </summary>
        public EvilTempBiome currentEvilBiome;

        public override void ResetEffects() {
            desiredTemperature = NormalTemperature;
            temperatureChangeResist = 0f;
            comfortableHigh = 30f;
            comfortableLow = 10f;
            criticalRangeMaximum = 10f;
        }

        #region Update Overrides
        //Reset Temperature upon death
        public override void UpdateDead() {
            currentTemperature = NormalTemperature;
        }

        public override void PostUpdateMiscEffects() {
            //Updating the player's current biome
            foreach (TempBiome biome in TerraTemp.tempBiomes) {
                if (biome.PlayerZoneBool) {
                    currentBiome = biome;
                    break;
                }
                //Current biome being null means the player is in Forest, the default biome
                if (!biome.PlayerZoneBool && biome == TerraTemp.tempBiomes.Last()) {
                    currentBiome = null;
                    break;
                }
            }

            //Updating the player's current evil biome
            foreach (EvilTempBiome biome in TerraTemp.evilTempBiomes) {
                if (biome.EvilZoneBool) {
                    currentEvilBiome = biome;
                    break;
                }
                //Current evil biome being null means the player is not in any evil biome, thus no change
                if (!biome.EvilZoneBool && biome == TerraTemp.evilTempBiomes.Last()) {
                    currentEvilBiome = null;
                    break;
                }
            }

            //Change desired temp & temperature resistance depending on the current biome, if applicable
            if (currentBiome != null) {
                desiredTemperature += currentBiome.TemperatureModification;
                temperatureChangeResist += currentBiome.TemperatureResistanceModification;
            }
            //Change desired temp & temperature resistance depending on the current evil biome, if applicable
            if (currentEvilBiome != null) {
                desiredTemperature += currentEvilBiome.TemperatureModification;
                temperatureChangeResist += currentEvilBiome.TemperatureResistanceModification;
            }

            //Change desired temp based on what time of day it is and the daily temperature devation
            //Day will be hottest at Noon, the night will be coldest at Midnight
            if (player.ZoneOverworldHeight) {
                if (Main.dayTime) {
                    if (Main.time <= 27000 /* Noon */) {
                        desiredTemperature += ((float)Main.time / 60f / 50f) * (float)TerraTemp.dailyTemperatureDeviation;
                    }
                    else {
                        desiredTemperature += ((54000f - (float)Main.time) / 60f / 50f) * (float)TerraTemp.dailyTemperatureDeviation;
                    }
                }
                else {
                    if (Main.time <= 16200 /* Midnight */) {
                        desiredTemperature -= ((float)Main.time / 60f / 30f) * (float)TerraTemp.dailyTemperatureDeviation;
                    }
                    else {
                        desiredTemperature -= ((32400f - (float)Main.time) / 60f / 30f) * (float)TerraTemp.dailyTemperatureDeviation;
                    }
                }
            }
        }

        public override void PostUpdate() {
            //Body temperature will change at a rate equivalent to the difference between the body temperature and desired temperature
            // multiplied by the player's temperature change resistance.
            float difference = desiredTemperature - currentTemperature;
            currentTemperature += difference / 60f / 45f * (1f - temperatureChangeResist);
        }

        #endregion

        #region Temperature Effects
        public override void PostUpdateBuffs() {
            //Heat Effects
            if (currentTemperature > comfortableHigh) {
                //Sweaty Effect
                if (currentTemperature < comfortableHigh + (criticalRangeMaximum / 2f)) {
                    player.AddBuff(ModContent.BuffType<Sweaty>(), 5);
                }
                //Heat Stroke
                else if (currentTemperature > comfortableHigh + (criticalRangeMaximum / 2f) && currentTemperature < comfortableHigh + criticalRangeMaximum) {
                    player.AddBuff(ModContent.BuffType<HeatStroke>(), 5);
                }
                //Death
                if (currentTemperature > comfortableHigh + criticalRangeMaximum) {
                    PlayerDeathReason deathReason = new PlayerDeathReason {
                        SourceCustomReason = player.name + " overheated."
                    };
                    player.KillMe(deathReason, 9999, 0);
                }
            }
            //Cold Effects
            else if (currentTemperature < comfortableLow) {
                //Chilly Effect
                if (currentTemperature > comfortableLow - (criticalRangeMaximum / 2f)) {
                    player.AddBuff(ModContent.BuffType<Shivering>(), 5);
                }
                //Hypothermia
                if (currentTemperature < comfortableLow - (criticalRangeMaximum / 2f) && currentTemperature > comfortableLow - criticalRangeMaximum) {
                    player.AddBuff(ModContent.BuffType<Hypothermia>(), 5);
                }
                //Death
                if (currentTemperature < comfortableLow - criticalRangeMaximum) {
                    PlayerDeathReason deathReason = new PlayerDeathReason {
                        SourceCustomReason = player.name + " froze to death."
                    };
                    player.KillMe(deathReason, 9999, 0);
                }
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
        #endregion
    }
}