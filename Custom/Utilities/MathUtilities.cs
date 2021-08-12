using System;
using Terraria;

namespace TerraTemp.Custom.Utilities {

    /// <summary>
    /// Class that has methods dealing with math and calculation related matters.
    /// </summary>
    public static class MathUtilities {

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

        /// <summary>
        /// Generates and returns a Temperature Deviation value.
        /// </summary>
        public static float GenerateTemperatureDeviation() => Main.rand.NextFloat(0.33f, 1.67f);

        /// <summary>
        /// Generates and returns a Humidity Deviation value.
        /// </summary>
        public static float GenerateHumidityDeviation() => Main.rand.NextFloat(-0.1f, 0.75f);
    }
}