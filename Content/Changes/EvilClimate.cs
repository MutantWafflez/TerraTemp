﻿using Terraria;
using TerraTemp.Custom.Interfaces;

namespace TerraTemp.Content.Changes {

    /// <summary>
    /// Class that is instantiated for each evil biome (including the Hallow) that affects
    /// temperature. Exists so the evil biomes can affect temperature on top of the normal biome effects.
    /// </summary>
    public abstract class EvilClimate : ITempStatChange {

        /// <summary>
        /// The typical temperature of the water in this evil biome. Defaults to reducing
        /// temperature by 2 degrees.
        /// </summary>
        public virtual float WaterTemperature => -2f;

        /// <summary>
        /// By how much this given evil biome will change the player's Base Desired (Environmental) Temperature.
        /// </summary>
        public virtual float GetDesiredTemperatureChange(Player player) => 0f;

        /// <summary>
        /// By how much this given evil biome will change the player's Relative Humidity.
        /// </summary>
        public virtual float GetHumidityChange(Player player) => 0f;

        /// <summary>
        /// By how much this given evil biome will change the player's Heat Comfortability Range.
        /// </summary>
        public virtual float GetHeatComfortabilityChange(Player player) => 0f;

        /// <summary>
        /// By how much this given evil biome will change the player's Cold Comfortability Range.
        /// </summary>
        public virtual float GetColdComfortabilityChange(Player player) => 0f;

        /// <summary>
        /// By how much this given evil biome will change the player's Temperature Resistance.
        /// </summary>
        public virtual float GetTemperatureResistanceChange(Player player) => 0f;

        /// <summary>
        /// By how much this given evil biome will change the player's critical temperature range.
        /// </summary>
        public virtual float GetCriticalTemperatureChange(Player player) => 0f;

        /// <summary>
        /// Biomes are unable to changes the Climate Extremity value since they are the things being
        /// modified by the Climate Extremity value in the first place.
        /// </summary>
        public float GetClimateExtremityChange(Player player) => 0f;

        /// <summary>
        /// By how much this given evil biome will change the player's sun extremity value (sun
        /// protection, essentially).
        /// </summary>
        public virtual float GetSunExtremityChange(Player player) => 0f;

        /// <summary>
        /// Zone bool that relates to this evil biome.
        /// </summary>
        public virtual bool EvilZoneBool(Player player) => false;
    }
}