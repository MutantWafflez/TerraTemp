using System;
using Terraria.Localization;
using System.Linq;
using Terraria;
using System.Collections.Generic;

namespace TerraTemp.Utilities {

    public class TempUtilities {

        public static float CelsiusToFahrenheit(float Celsius, bool Round = false) {
            if (!Round) {
                return (Celsius * (9f / 5f)) + 32f;
            }
            else {
                return (float)Math.Round((Celsius * (9f / 5f)) + 32f);
            }
        }

        public static float CelsiusToFahrenheit(double Celsius, bool Round = false) {
            if (!Round) {
                return (float)(Celsius * (9f / 5f)) + 32f;
            }
            else {
                return (float)Math.Round((Celsius * (9f / 5f)) + 32f);
            }
        }

        /// <summary>
        /// Shorthand method that will get the Localization text for the given key in the TerraTemp mod.
        /// </summary>
        /// <param name="key"> The key for the localization text. </param>
        /// <param name="arg0">
        /// If the given localization text has a argument, this is where that can be input.
        /// </param>
        /// <returns> The given string value attached to input key, if it exists. </returns>
        public static string GetTerraTempTextValue(string key, object arg0 = null) {
            if (arg0 != null) {
                return Language.GetTextValue("Mods.TerraTemp." + key, arg0);
            }
            else {
                return Language.GetTextValue("Mods.TerraTemp." + key);
            }
        }

        /// <summary>
        /// Method that create new localized line(s) based on what statistics a given change will
        /// modify about a player.
        /// </summary>
        /// <param name="heatComfortabilityChange">
        /// How much this change will modify the player's heat comfortability range.
        /// </param>
        /// <param name="coldComfortabilityChange">
        /// How much this change will modify the player's cold comfortability range.
        /// </param>
        /// <param name="temperatureResistanceChange">
        /// How much this change will modify the player's temperature change rate resistance.
        /// </param>
        /// <param name="criticalRangeChange">
        /// How much this change will modify the player's critical range.
        /// </param>
        /// <returns> Localized lines(s) that say what the change has done to player's stats. </returns>
        public static string CreateNewLineBasedOnStats(float heatComfortabilityChange, float coldComfortabilityChange, float temperatureResistanceChange, float criticalRangeChange) {
            float heatChange = Math.Abs(heatComfortabilityChange);
            float coldChange = Math.Abs(coldComfortabilityChange);
            float tempResistChange = Math.Abs(temperatureResistanceChange);
            float criticalChange = Math.Abs(criticalRangeChange);

            string fullLine = "";
            List<string> stringsToAdd = new List<string>();

            //Global Change Check
            if (heatComfortabilityChange * -1 == coldComfortabilityChange && heatChange != 0f) {
                if (heatComfortabilityChange > 0f) {
                    stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.IncreasedGlobalComfortability", heatChange));
                }
                else if (heatComfortabilityChange < 0f) {
                    stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.DecreasedGlobalComfortability", heatChange));
                }
            }
            //Heat/Cold Change Check
            else {
                if (heatComfortabilityChange > 0f) {
                    stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.IncreasedHeatComfortability", heatChange));
                }
                else if (heatComfortabilityChange < 0f) {
                    stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.DecreasedHeatComfortability", heatChange));
                }

                if (coldComfortabilityChange < 0f) {
                    stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.IncreasedColdComfortability", coldChange));
                }
                else if (coldComfortabilityChange > 0f) {
                    stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.DecreasedColdComfortability", coldChange));
                }
            }

            //Temperature Resistance Change Check
            if (temperatureResistanceChange > 0f) {
                stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.IncreasedTempResistance", tempResistChange));
            }
            else if (temperatureResistanceChange < 0f) {
                stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.DecreasedTempResistance", tempResistChange));
            }

            //Critical Temperature Change Check
            if (criticalRangeChange > 0f) {
                stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.IncreasedCriticalRange", criticalChange));
            }
            else if (criticalRangeChange < 0f) {
                stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.DecreasedCriticalRange", criticalChange));
            }

            if (stringsToAdd.Any()) {
                foreach (string line in stringsToAdd) {
                    fullLine += line + (line != stringsToAdd.Last() ? "\n" : "");
                }
            }

            return fullLine == "" ? null : fullLine;
        }
    }
}