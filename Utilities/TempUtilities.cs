using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Calculates what the environment temperature would feel like to someone with humidity
        /// taken into account. Uses the formula to calculate the heat-index with the temperature in
        /// celsius above 27C. https://en.wikipedia.org/wiki/Heat_index#Formula For below 27C, we
        /// use our own custom "formula" since a real life formula hasn't been found/created to
        /// explain why cold, humid air is colder than cold, dry air.
        /// </summary>
        /// <param name="environmentTemperature"> The environment's temperature, in Celsius. </param>
        /// <param name="relativeHumidity">
        /// The current relative humditidy, as a value from 0f to 1f.
        /// </param>
        /// <returns>
        /// An increased/decreased evironment temperature with humidity taken into account.
        /// </returns>
        public static float EnvironmentTemperatureWithHumidity(float environmentTemperature, float relativeHumidity) {
            if (environmentTemperature >= 27f) {
                float constantOne = -8.78469475556f;
                float constantTwo = 1.61139411f;
                float constantThree = 2.33854883889f;
                float constantFour = -0.14611605f;
                float constantFive = -0.012308094f;
                float constantSix = -0.0164248277778f;
                float constantSeven = 0.002211732f;
                float constantEight = 0.00072546f;
                float constantNine = -0.000003582f;

                relativeHumidity *= 100f;

                float heatIndexedTemperature = 0f;

                heatIndexedTemperature += constantOne;
                heatIndexedTemperature += constantTwo * environmentTemperature;
                heatIndexedTemperature += constantThree * relativeHumidity;
                heatIndexedTemperature += constantFour * environmentTemperature * relativeHumidity;
                heatIndexedTemperature += constantFive * (float)Math.Pow(environmentTemperature, 2f);
                heatIndexedTemperature += constantSix * (float)Math.Pow(relativeHumidity, 2f);
                heatIndexedTemperature += constantSeven * (float)Math.Pow(environmentTemperature, 2f) * relativeHumidity;
                heatIndexedTemperature += constantEight * environmentTemperature * (float)Math.Pow(relativeHumidity, 2f);
                heatIndexedTemperature += constantNine * (float)Math.Pow(environmentTemperature, 2f) * (float)Math.Pow(relativeHumidity, 2f);

                return heatIndexedTemperature;
            }
            else {
                return environmentTemperature - (8f * relativeHumidity);
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
            float tempResistChange = Math.Abs(temperatureResistanceChange) * 100f; //Times 100 because its a percentage
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