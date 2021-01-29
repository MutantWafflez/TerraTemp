using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using TerraTemp.Custom.Attributes;
using TerraTemp.Custom.Interfaces;

namespace TerraTemp.Custom {

    /// <summary>
    /// Class that has several important helper methods for this mod to make things a bit easier.
    /// </summary>
    public static class TempUtilities {

        /// <summary>
        /// The string of the directory for all of the miscellaneous textures for TerraTemp.
        /// </summary>
        public const string TEXTURE_DIRECTORY = nameof(TerraTemp) + "/Content/Textures/";

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
        /// Method that expresses the potential effects of any possible "shade" that the player
        /// might be under on the temperature increase imposed by the sun. Is based on whether or
        /// not the player is behind a wall and has any tiles 16 or less blocks above them.
        /// </summary>
        /// <returns> Value from 0f to 1f. </returns>
        public static float GetShadeEffectsOnSunTemperature(Player player) {
            if (player.behindBackWall) {
                if (player.IsUnderRoof()) {
                    return 0.34f;
                }
                else {
                    return 0.75f;
                }
            }
            else {
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
        /// <param name="statChanges"> The object that contains all of the stat changing data. </param>
        /// <param name="additionalLine"> Any additional non-automated line to be added, if necessary. </param>
        /// <returns> Localized lines(s) that say what the change has done to player's stats. </returns>
        public static string CreateNewLineBasedOnStats(ITempStatChange statChanges, string additionalLine = null) {
            Player player = Main.LocalPlayer;

            float desiredTempChange = statChanges.GetDesiredTemperatureChange(player);
            float humidityChange = statChanges.GetHumidityChange(player);
            float heatComfortabilityChange = statChanges.GetHeatComfortabilityChange(player);
            float coldComfortabilityChange = statChanges.GetColdComfortabilityChange(player);
            float temperatureResistanceChange = statChanges.GetTemperatureResistanceChange(player);
            float criticalRangeChange = statChanges.GetCriticalTemperatureChange(player);
            float climateExtremityChange = statChanges.GetClimateExtremityChange(player);
            float sunExtremityChange = statChanges.GetSunExtremityChange(player);

            float absDesiredTempChange = Math.Abs(desiredTempChange);
            float absHumidityChange = Math.Abs(humidityChange) * 100f; //Times 100 because it's a percentage
            float absHeatComfortabilityChange = Math.Abs(heatComfortabilityChange);
            float absColdComfortabilityChange = Math.Abs(coldComfortabilityChange);
            float absTemperatureResistanceChange = Math.Abs(temperatureResistanceChange) * 100f; //Times 100 because it's a percentage
            float absCriticalRangeChange = Math.Abs(criticalRangeChange);
            float absClimateExtremityChange = Math.Abs(climateExtremityChange) * 100f; //Times 100 because it's a percentage
            float absSunExtremityChange = Math.Abs(sunExtremityChange) * 100f; //Times 100 because it's a percentage

            string fullLine = "";
            List<string> stringsToAdd = new List<string>();

            //Desired Temperature Change Check
            if (desiredTempChange > 0f) {
                stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.IncreasedDesiredTemp", absDesiredTempChange));
            }
            else if (desiredTempChange < 0f) {
                stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.DecreasedDesiredTemp", absDesiredTempChange));
            }

            //Humidity Change Check
            if (absHumidityChange > 0f) {
                stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.IncreasedHumidity", humidityChange));
            }
            else if (absHumidityChange < 0f) {
                stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.DecreasedHumidity", humidityChange));
            }

            //Global Change Check
            if (heatComfortabilityChange * -1 == coldComfortabilityChange && absHeatComfortabilityChange != 0f) {
                if (heatComfortabilityChange > 0f) {
                    stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.IncreasedGlobalComfortability", absHeatComfortabilityChange));
                }
                else if (heatComfortabilityChange < 0f) {
                    stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.DecreasedGlobalComfortability", absHeatComfortabilityChange));
                }
            }
            //Heat/Cold Change Check
            else {
                if (heatComfortabilityChange > 0f) {
                    stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.IncreasedHeatComfortability", absHeatComfortabilityChange));
                }
                else if (heatComfortabilityChange < 0f) {
                    stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.DecreasedHeatComfortability", absHeatComfortabilityChange));
                }

                if (coldComfortabilityChange < 0f) {
                    stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.IncreasedColdComfortability", absColdComfortabilityChange));
                }
                else if (coldComfortabilityChange > 0f) {
                    stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.DecreasedColdComfortability", absColdComfortabilityChange));
                }
            }

            //Temperature Resistance Change Check
            if (temperatureResistanceChange > 0f) {
                stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.IncreasedTempResistance", absTemperatureResistanceChange));
            }
            else if (temperatureResistanceChange < 0f) {
                stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.DecreasedTempResistance", absTemperatureResistanceChange));
            }

            //Critical Temperature Change Check
            if (criticalRangeChange > 0f) {
                stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.IncreasedCriticalRange", absCriticalRangeChange));
            }
            else if (criticalRangeChange < 0f) {
                stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.DecreasedCriticalRange", absCriticalRangeChange));
            }

            //Climate Extremity Change Check
            if (climateExtremityChange > 0f) {
                stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.IncreasedClimateExtremity", absClimateExtremityChange));
            }
            else if (climateExtremityChange < 0f) {
                stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.DecreasedClimateExtremity", absClimateExtremityChange));
            }

            //Sun Extremity Change Check
            if (sunExtremityChange > 0f) {
                stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.IncreasedSunExtremity", absSunExtremityChange));
            }
            else if (sunExtremityChange < 0f) {
                stringsToAdd.Add(GetTerraTempTextValue("GlobalTooltip.DecreasedSunExtremity", absSunExtremityChange));
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

        /// <summary>
        /// Returns whether or not this given player is under a roof. Being "under a roof"
        /// constitutes that there are two blocks somewhere at least 16 blocks above the player.
        /// </summary>
        public static bool IsUnderRoof(this Player player) {
            return !Collision.CanHitLine(new Vector2(player.Center.X + 8f, player.Top.Y), 4, 4, new Vector2(player.Center.X + 8f, player.Top.Y - 16 * 17), 4, 4) && !Collision.CanHitLine(new Vector2(player.Center.X - 8f, player.Top.Y), 4, 4, new Vector2(player.Center.X - 8f, player.Top.Y - 16 * 17), 4, 4);
        }

        #endregion

        #region Stat Methods

        /// <summary>
        /// Automatically applies the stat changes to the given player for any given change, as long
        /// as it implements the <see cref="ITempStatChange"/> interface.
        /// </summary>
        /// <param name="statChanges"> The stat changes instance. </param>
        /// <param name="player"> The player to apply the stat changes to. </param>
        public static void ApplyStatChanges(ITempStatChange statChanges, Player player) {
            TempPlayer temperaturePlayer = player.GetTempPlayer();

            temperaturePlayer.baseDesiredTemperature += statChanges.GetDesiredTemperatureChange(player);
            temperaturePlayer.relativeHumidity += statChanges.GetHumidityChange(player);
            temperaturePlayer.comfortableHigh += statChanges.GetHeatComfortabilityChange(player);
            temperaturePlayer.comfortableLow += statChanges.GetColdComfortabilityChange(player);
            temperaturePlayer.temperatureChangeResist += statChanges.GetTemperatureResistanceChange(player);
            temperaturePlayer.criticalRangeMaximum += statChanges.GetCriticalTemperatureChange(player);
            temperaturePlayer.climateExtremityValue += statChanges.GetClimateExtremityChange(player);
            temperaturePlayer.sunExtremityValue += statChanges.GetSunExtremityChange(player);
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
                    TerraTemp.TTLogging.Info("Item " + recipe.createItem.Name + " found with containing the ingredient with the ID of " + ingredientID);

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
    }
}