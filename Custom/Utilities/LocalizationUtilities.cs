using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using TerraTemp.Custom.Interfaces;
using TerraTemp.Custom.Structs;

namespace TerraTemp.Custom.Utilities {

    /// <summary>
    /// Class that has methods dealing with localization related matters.
    /// </summary>
    public static class LocalizationUtilities {

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

        /// <summary>
        /// Method that create new localized line(s) based on what statistics a given prefix will
        /// modify about a player's stats when given item is worn.
        /// </summary>
        /// <param name="statChanges"> The object that contains all of the stat changing data. </param>
        /// <param name="additionalLine"> Any additional non-automated line to be added, if necessary. </param>
        /// <returns> Localized lines(s) that say what the change has done to player's stats. </returns>
        public static List<ColoredString> CreatePrefixStatLines(ITempStatChange statChanges) {
            Player player = Main.LocalPlayer;

            float desiredTempChange = statChanges.GetDesiredTemperatureChange(player);
            float humidityChange = statChanges.GetHumidityChange(player);
            float heatComfortabilityChange = statChanges.GetHeatComfortabilityChange(player);
            float coldComfortabilityChange = statChanges.GetColdComfortabilityChange(player);
            float temperatureResistanceChange = statChanges.GetTemperatureResistanceChange(player);
            float criticalRangeChange = statChanges.GetCriticalTemperatureChange(player);
            float climateExtremityChange = statChanges.GetClimateExtremityChange(player);
            float sunExtremityChange = statChanges.GetSunExtremityChange(player);

            float percentHumidityChange = humidityChange * 100f;
            float percentTemperatureResistanceChange = temperatureResistanceChange * 100f;
            float percentClimateExtremityChange = climateExtremityChange * 100f;
            float percentSunExtremityChange = sunExtremityChange * 100f;

            Color modifierGreen = new Color(190, 120, 120);
            Color modifierRed = new Color(120, 190, 120);
            Color modifierGray = new Color(190, 190, 190);

            List<ColoredString> stringsToAdd = new List<ColoredString>();

            //Desired Temperature Change Check
            if (Math.Abs(desiredTempChange) > 0f) {
                //This has a special check since changing body temperature is good/bad depending on context, thus it will be gray in color
                stringsToAdd.Add(new ColoredString((desiredTempChange > 0f ? "+" : "") + GetTerraTempTextValue("GlobalTooltip.DesiredTempPrefix", desiredTempChange), modifierGray));
            }

            //Humidity Change Check
            if (Math.Abs(humidityChange) > 0f) {
                stringsToAdd.Add(new ColoredString((humidityChange > 0f ? "+" : "") + GetTerraTempTextValue("GlobalTooltip.HumidityPrefix", percentHumidityChange), humidityChange > 0f ? modifierGreen : modifierRed));
            }

            //Global Change Check
            if (heatComfortabilityChange * -1f == coldComfortabilityChange && Math.Abs(heatComfortabilityChange) != 0f) {
                stringsToAdd.Add(new ColoredString((heatComfortabilityChange > 0f ? "+" : "") + GetTerraTempTextValue("GlobalTooltip.GlobalComfortabilityPrefix", heatComfortabilityChange), heatComfortabilityChange < 0f ? modifierGreen : modifierRed));
            }
            //Heat/Cold Change Check
            else {
                if (Math.Abs(heatComfortabilityChange) > 0f) {
                    stringsToAdd.Add(new ColoredString((heatComfortabilityChange > 0f ? "+" : "") + GetTerraTempTextValue("GlobalTooltip.HeatComfortabilityPrefix", heatComfortabilityChange), heatComfortabilityChange < 0f ? modifierGreen : modifierRed));
                }

                if (Math.Abs(coldComfortabilityChange) > 0f) {
                    stringsToAdd.Add(new ColoredString((coldComfortabilityChange > 0f ? "+" : "") + GetTerraTempTextValue("GlobalTooltip.ColdComfortabilityPrefix", coldComfortabilityChange), coldComfortabilityChange > 0f ? modifierGreen : modifierRed));
                }
            }

            //Temperature Resistance Change Check
            if (Math.Abs(temperatureResistanceChange) > 0f) {
                stringsToAdd.Add(new ColoredString((temperatureResistanceChange > 0f ? "+" : "") + GetTerraTempTextValue("GlobalTooltip.TempResistancePrefix", percentTemperatureResistanceChange), temperatureResistanceChange < 0f ? modifierGreen : modifierRed));
            }

            //Critical Temperature Change Check
            if (Math.Abs(criticalRangeChange) > 0f) {
                stringsToAdd.Add(new ColoredString((criticalRangeChange > 0f ? "+" : "") + GetTerraTempTextValue("GlobalTooltip.CriticalRangePrefix", criticalRangeChange), criticalRangeChange < 0f ? modifierGreen : modifierRed));
            }

            //Climate Extremity Change Check
            if (Math.Abs(climateExtremityChange) > 0f) {
                stringsToAdd.Add(new ColoredString((climateExtremityChange > 0f ? "+" : "") + GetTerraTempTextValue("GlobalTooltip.ClimateExtremityPrefix", percentClimateExtremityChange), climateExtremityChange > 0f ? modifierGreen : modifierRed));
            }

            //Sun Extremity Change Check
            if (Math.Abs(sunExtremityChange) > 0f) {
                stringsToAdd.Add(new ColoredString((sunExtremityChange > 0f ? "+" : "") + GetTerraTempTextValue("GlobalTooltip.SunExtremityPrefix", percentSunExtremityChange), sunExtremityChange > 0f ? modifierGreen : modifierRed));
            }

            return stringsToAdd;
        }
    }
}