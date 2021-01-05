using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Terraria;
using Terraria.Localization;

namespace TerraTemp.Utilities {

    public static class TempUtilities {

        #region Calculation Methods

        /// <summary>
        /// Converted a Celsius Temperature to Fahrenheit.
        /// </summary>
        /// <param name="Celsius"> Temperatue value, in celsius. </param>
        /// <param name="Round"> Whether or not to round the final value. </param>
        /// <returns> </returns>
        public static float CelsiusToFahrenheit(float Celsius, bool Round = false) {
            if (!Round) {
                return (Celsius * (9f / 5f)) + 32f;
            }
            else {
                return (float)Math.Round((Celsius * (9f / 5f)) + 32f);
            }
        }

        /// <summary>
        /// Converted a Celsius Temperature to Fahrenheit.
        /// </summary>
        /// <param name="Celsius"> Temperatue value, in celsius. </param>
        /// <param name="Round"> Whether or not to round the final value. </param>
        /// <returns> </returns>
        public static float CelsiusToFahrenheit(double Celsius, bool Round = false) {
            if (!Round) {
                return (float)(Celsius * (9f / 5f)) + 32f;
            }
            else {
                return (float)Math.Round((Celsius * (9f / 5f)) + 32f);
            }
        }

        /// <summary>
        /// Simple method that expresses the effects that the current status of the clouds has on
        /// the temperature increase imposed by the sun. For example, if it's noon and Overcast, the
        /// increase in temperature won't be as potent since the Sun will be "blocked" by clouds for
        /// the most part.
        /// </summary>
        /// <returns> Value from 0f to 1f. </returns>
        public static float GetCloudEffectsOnSunTemperature() {
            if (Main.cloudBGActive > 0f) { //Equivalent to "Overcast"
                return 0.5f;
            }
            else if (Main.numClouds > 120) { //Equivalent to "Mostly Cloudy"
                return 0.75f;
            }
            else if (Main.numClouds > 80) { //Equivalent to "Cloudy"
                return 0.85f;
            }
            else { //Equivalent to "Clear" or "Partly Cloudy"
                return 1f;
            }
        }

        /// <summary>
        /// Real life formula that calculates the Apparent temperature at any given time, applying
        /// factors of the environment temperature, relative humidity, and wind speed. https://en.wikipedia.org/wiki/Wind_chill#Australian_apparent_temperature
        /// </summary>
        /// <param name="environmentTemperature">
        /// The base temperature of the environment, in Celsius.
        /// </param>
        /// <param name="relativeHumidity">
        /// The relative humidity of the environment, a value from 0f to 1f.
        /// </param>
        /// <param name="windSpeed"> The wind speed, in m/s. </param>
        /// <returns> </returns>
        public static float CalculateApparentTemperature(float environmentTemperature, float relativeHumidity, float windSpeed) {
            float waterVapourPressure = relativeHumidity * 6.105f * (float)Math.Pow(Math.E, 17.27f * environmentTemperature / (237.7f + environmentTemperature));

            float apparentTemperature = environmentTemperature + 0.33f * waterVapourPressure - 0.7f * windSpeed - 4f;

            return apparentTemperature;
        }

        #endregion

        #region Localization Methods

        /// <summary>
        /// Shorthand method that will get the Localization text for the given key in the TerraTemp mod.
        /// </summary>
        /// <param name="key"> The key for the localization text. </param>
        /// <param name="arg0">
        /// If the given localization text has a argument, this is where that can be input.
        /// </param>
        /// <param name="useRegexSearch">
        /// Whether or not to use Regex to search for potential keys within the original key return.
        /// </param>
        /// <returns> The given string value attached to input key, if it exists. </returns>
        public static string GetTerraTempTextValue(string key, object arg0 = null, bool useRegexSearch = false) {
            if (arg0 != null) {
                string returnedValue = Language.GetTextValue("Mods.TerraTemp." + key, arg0);
                if (useRegexSearch) {
                    return DoRegexSearch(returnedValue);
                }
                return returnedValue;
            }
            else {
                string returnedValue = Language.GetTextValue("Mods.TerraTemp." + key);
                if (useRegexSearch) {
                    return DoRegexSearch(returnedValue);
                }
                return returnedValue;
            }

            string DoRegexSearch(string stringToSearch) {
                MatchCollection bracketsExist = Regex.Matches(stringToSearch, @"\{(.*?)\}");
                if (bracketsExist.Count > 0) {
                    string newString = "";
                    for (int i = 0; i < bracketsExist.Count; i++) {
                        MatchCollection regMatches = Regex.Matches(stringToSearch, @"(\[(?:\[??[^\[]*?\]))|(\((?:\(??[^\[]*?\)))");
                        if (regMatches.Count % 2 == 0 && regMatches.Count != 0) {
                            for (int x = 0; x < regMatches.Count; x += 2) {
                                if (regMatches[x].Value.Contains("[") && regMatches[x + 1].Value.Contains("(")) {
                                    string newKey = regMatches[x].Value.Trim(new char[] { '[', ']' });
                                    string newarg0 = regMatches[x + 1].Value.Trim(new char[] { '(', ')' });

                                    newString = stringToSearch.Replace(bracketsExist[i].Value, Language.GetTextValue(newKey, newarg0));
                                }
                            }
                        }
                    }
                    return newString;
                }
                return stringToSearch;
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
        /// ///
        /// <param name="desiredTempChange">
        /// How much this will change the player's desired temperature, AKA the "environment" temperature.
        /// </param>
        /// <returns> Localized lines(s) that say what the change has done to player's stats. </returns>
        public static string CreateNewLineBasedOnStats(float heatComfortabilityChange, float coldComfortabilityChange, float temperatureResistanceChange, float criticalRangeChange, float desiredTempChange) {
            float heatChange = Math.Abs(heatComfortabilityChange);
            float coldChange = Math.Abs(coldComfortabilityChange);
            float tempResistChange = Math.Abs(temperatureResistanceChange) * 100f; //Times 100 because its a percentage
            float criticalChange = Math.Abs(criticalRangeChange);
            float desiredChange = Math.Abs(desiredTempChange);

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

            //Desired Temperature Change Check
            if (desiredTempChange > 0f) {
                stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.IncreasedDesiredTemp", desiredChange));
            }
            else if (desiredTempChange < 0f) {
                stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.DecreasedDesiredTemp", desiredChange));
            }

            if (stringsToAdd.Any()) {
                foreach (string line in stringsToAdd) {
                    fullLine += line + (line != stringsToAdd.Last() ? "\n" : "");
                }
            }

            return fullLine == "" ? null : fullLine;
        }

        #endregion

        #region Extension Methods

        /// <summary>
        /// Shorthand method that returns the given player's TempPlayer ModPlayer.
        /// </summary>
        public static TempPlayer GetTempPlayer(this Player player) => player.GetModPlayer<TempPlayer>();

        #endregion

        #region Miscellaneous Methods

        /// <summary>
        /// Returns a List of Types that aren't abstract that extend the class T.
        /// </summary>
        /// <typeparam name="T"> The Class to get the children of. </typeparam>
        public static List<Type> GetAllChildrenOfClass<T>() {
            return Assembly.GetExecutingAssembly().GetTypes().Where(type => type.IsSubclassOf(typeof(T)) && !type.IsAbstract).ToList();
        }

        #endregion
    }
}