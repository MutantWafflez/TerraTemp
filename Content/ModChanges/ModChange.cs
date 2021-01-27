using Terraria;
using TerraTemp.Custom.Attributes;
using TerraTemp.Custom.Classes.ReflectionMod;
using TerraTemp.Custom.Interfaces;

namespace TerraTemp.Content.ModChanges {

    /// <summary>
    /// Abstract base class that handles ALL compatible modded changes, including events and biomes.
    /// </summary>
    [PertainedMod(null)]
    public abstract class ModChange : ITempStatChange {

        /// <summary>
        /// The instance of the class in the <see cref="TerraTemp.activeCompatibleMods"/> list.
        /// </summary>
        public readonly ReflectionMod reflectionModInstance;

        public ModChange(ReflectionMod reflectionMod) {
            reflectionModInstance = reflectionMod;
        }

        /// <summary>
        /// By how much this given mod event will change the player's Base Desired (Environmental) Temperature.
        /// </summary>
        public virtual float GetDesiredTemperatureChange(Player player) => 0f;

        /// <summary>
        /// By how much this given mod event will change the player's Relative Humidity.
        /// </summary>
        public virtual float GetHumidityChange(Player player) => 0f;

        /// <summary>
        /// By how much this given mod event will change the player's Heat Comfortability Range.
        /// </summary>
        public virtual float GetHeatComfortabilityChange(Player player) => 0f;

        /// <summary>
        /// By how much this given mod event will change the player's Cold Comfortability Range.
        /// </summary>
        public virtual float GetColdComfortabilityChange(Player player) => 0f;

        /// <summary>
        /// By how much this given mod event will change the player's Temperature Resistance.
        /// </summary>
        public virtual float GetTemperatureResistanceChange(Player player) => 0f;

        /// <summary>
        /// By how much this given mod event will change the player's critical temperature range.
        /// </summary>
        public virtual float GetCriticalTemperatureChange(Player player) => 0f;

        /// <summary>
        /// By how much this given mod event will change the player's climate extremity value.
        /// </summary>
        public virtual float GetClimateExtremityChange(Player player) => 0f;

        /// <summary>
        /// By how much this given mod event will change the player's sun extremity value (sun
        /// protection, essentially).
        /// </summary>
        public virtual float GetSunExtremityChange(Player player) => 0f;
    }
}