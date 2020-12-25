using System;
using Terraria.Localization;

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
        public static string GetTerraTempTextValue(string key, object arg0 = null, bool addEndingLineBreak = false) {
            if (arg0 != null) {
                return Language.GetTextValue("Mods.TerraTemp." + key, arg0) + (addEndingLineBreak ? "\n" : "");
            }
            else {
                return Language.GetTextValue("Mods.TerraTemp." + key) + (addEndingLineBreak ? "\n" : "");
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

            //Global Change Check
            if (heatComfortabilityChange * -1 == coldComfortabilityChange && heatChange != 0f) {
                if (heatComfortabilityChange > 0f) {
                    fullLine += GetTerraTempTextValue("GlobalTooltip.IncreasedGlobalComfortability", heatChange, true);
                }
                else if (heatComfortabilityChange < 0f) {
                    fullLine += GetTerraTempTextValue("GlobalTooltip.DecreasedGlobalComfortability", heatChange, true);
                }
            }
            //Heat/Cold Change Check
            else {
                if (heatComfortabilityChange > 0f) {
                    fullLine += GetTerraTempTextValue("GlobalTooltip.IncreasedHeatComfortability", heatChange, true);
                }
                else if (heatComfortabilityChange < 0f) {
                    fullLine += GetTerraTempTextValue("GlobalTooltip.DecreasedHeatComfortability", heatChange, true);
                }

                if (coldComfortabilityChange < 0f) {
                    fullLine += GetTerraTempTextValue("GlobalTooltip.IncreasedColdComfortability", coldChange, true);
                }
                else if (coldComfortabilityChange > 0f) {
                    fullLine += GetTerraTempTextValue("GlobalTooltip.DecreasedColdComfortability", coldChange, true);
                }
            }

            //Temperature Resistance Change Check
            if (temperatureResistanceChange > 0f) {
                fullLine += GetTerraTempTextValue("GlobalTooltip.IncreasedTempResistance", tempResistChange, true);
            }
            else if (temperatureResistanceChange < 0f) {
                fullLine += GetTerraTempTextValue("GlobalTooltip.DecreasedTempResistance", tempResistChange, true);
            }

            //Critical Temperature Change Check
            if (criticalRangeChange > 0f) {
                fullLine += GetTerraTempTextValue("GlobalTooltip.IncreasedCriticalRange", criticalChange, true);
            }
            else if (criticalRangeChange < 0f) {
                fullLine += GetTerraTempTextValue("GlobalTooltip.DecreasedCriticalRange", criticalChange, true);
            }

            return fullLine == "" ? null : fullLine;
        }
    }
}