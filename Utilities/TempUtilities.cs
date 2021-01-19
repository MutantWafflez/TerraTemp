using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using TerraTemp.Content.Changes;

namespace TerraTemp.Utilities {

    /// <summary>
    /// Class that has several important helper methods for this mod to make things a bit easier.
    /// </summary>
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
        /// Method that expresses how much the current rain status will affect the current relative
        /// humidity. The "heavier" the rain, the more humid it will be, and the lighter the rain
        /// the less humid it will be (but it will still have a large increase on humidity
        /// regardless). "Heavy" raining is &gt; 0.6, "Normal" raining is &gt;= 0.2, Light raining
        /// is &gt; 0.
        /// </summary>
        public static float GetRainEffectsOnHumidity() {
            if (Main.maxRaining > 0.6) {
                return 0.9f;
            }
            else {
                return Main.maxRaining / 0.6f * 0.9f;
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
        /// <param name="desiredTempChange">
        /// How much this will change the player's desired temperature, AKA the "environment" temperature.
        /// </param>
        /// <param name="climateExtremityChange">
        /// How much this will change the player's climate extremity value.
        /// </param>
        /// <returns> Localized lines(s) that say what the change has done to player's stats. </returns>
        public static string CreateNewLineBasedOnStats(float heatComfortabilityChange, float coldComfortabilityChange, float temperatureResistanceChange, float criticalRangeChange, float desiredTempChange, float climateExtremityChange, string additionalLine = null) {
            float heatChange = Math.Abs(heatComfortabilityChange);
            float coldChange = Math.Abs(coldComfortabilityChange);
            float tempResistChange = Math.Abs(temperatureResistanceChange) * 100f; //Times 100 because it's a percentage
            float criticalChange = Math.Abs(criticalRangeChange);
            float desiredChange = Math.Abs(desiredTempChange);
            float climateExtreme = Math.Abs(climateExtremityChange) * 100f; //Times 100 because it's a percentage

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

            //Climate Extremity Change Check
            if (climateExtremityChange > 0f) {
                stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.IncreasedClimateExtremity", climateExtreme));
            }
            else if (climateExtremityChange < 0f) {
                stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.DecreasedClimateExtremity", climateExtreme));
            }

            //Desired Temperature Change Check
            if (desiredTempChange > 0f) {
                stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.IncreasedDesiredTemp", desiredChange));
            }
            else if (desiredTempChange < 0f) {
                stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.DecreasedDesiredTemp", desiredChange));
            }

            if (additionalLine != null) {
                stringsToAdd.Add(additionalLine);
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

        #region Derived Item Methods

        /// <summary>
        /// Does a "deep search" of all currently available recipes, whether it be vanilla or
        /// modded. Make sure to call this in PostAddRecipes() in the mod class to check for modded
        /// recipes as well.
        /// </summary>
        /// <param name="ingredientID"> The ID of the item to search for. </param>
        /// <returns>
        /// A HashSet of IDs for each item that contains the item with the ID of <paramref
        /// name="ingredientID"/> ANYWHERE in its crafting tree.
        /// </returns>
        public static HashSet<int> DeepRecipeSearch(int ingredientID) {
            HashSet<int> derivedItems = new HashSet<int>();

            void SearchAnotherLayer(int nextSearchIngredient) {
                RecipeFinder finder = new RecipeFinder();
                finder.AddIngredient(nextSearchIngredient);
                foreach (Recipe recipe in finder.SearchRecipes()) {
                    derivedItems.Add(recipe.createItem.type);

                    RecipeFinder checkForMaterial = new RecipeFinder();
                    checkForMaterial.AddIngredient(recipe.createItem.type);
                    if (checkForMaterial.SearchRecipes().Any()) {
                        SearchAnotherLayer(recipe.createItem.type);
                    }
                }
            }

            SearchAnotherLayer(ingredientID);

            return derivedItems;
        }

        #endregion

        #region Miscellaneous Methods

        /// <summary>
        /// Returns a List of Types that aren't abstract that extend the class T.
        /// </summary>
        /// <typeparam name="T"> The Class to get the children of. </typeparam>
        public static List<Type> GetAllChildrenOfClass<T>() {
            return Assembly.GetExecutingAssembly().GetTypes().Where(type => type.IsSubclassOf(typeof(T)) && !type.IsAbstract && type.GetCustomAttribute<IgnoredSubclassAttribute>() == null).ToList();
        }

        /// <summary>
        /// A more advanced Contains() method for lists that will check whether or not a given list
        /// has any values that is contained in another list. To be precise, <paramref
        /// name="containingList"/> is searched to see if it contains any items from <paramref name="listQuery"/>.
        /// </summary>
        /// <typeparam name="T"> Class of both of the lists. </typeparam>
        /// <param name="containingList"> List to be searched. </param>
        /// <param name="listQuery">
        /// List with potential children to be checked in the <paramref name="containingList"/> list.
        /// </param>
        /// <returns> </returns>
        public static bool ContainsList<T>(List<T> containingList, List<T> listQuery) {
            foreach (T thing in listQuery) {
                if (containingList.Contains(thing)) {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}