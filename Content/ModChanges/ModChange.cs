using TerraTemp.Custom.Attributes;
using TerraTemp.Custom.Classes.ReflectionMod;

namespace TerraTemp.Content.ModChanges {

    /// <summary>
    /// Abstract base class that handles ALL compatible modded changes, including events and biomes.
    /// </summary>
    [PertainedMod(null)]
    public abstract class ModChange {

        /// <summary>
        /// The instance of the class in the <see cref="TerraTemp.activeCompatibleMods"/> list.
        /// </summary>
        public readonly ReflectionMod reflectionModInstance;

        /// <summary>
        /// By how much this given change will change the player's Base Desired (Environmental) Temperature.
        /// </summary>
        public virtual float DesiredTemperatureChange => 0f;

        /// <summary>
        /// By how much this given change will change the environment's relative humidity.
        /// </summary>
        public virtual float HumidityChange => 0f;

        /// <summary>
        /// By how much this given change will change the player's Heat Comfortability Range.
        /// </summary>
        public virtual float HeatComfortabilityChange => 0f;

        /// <summary>
        /// By how much this given change will change the player's Cold Comfortability Range.
        /// </summary>
        public virtual float ColdComfortabilityChange => 0f;

        /// <summary>
        /// By how much this given change will change the player's Temperature Resistance.
        /// </summary>
        public virtual float TemperatureResistanceChange => 0f;

        /// <summary>
        /// By how much this given change will change the player's critical temperature range.
        /// </summary>
        public virtual float CriticalTemperatureChange => 0f;

        public ModChange(ReflectionMod reflectionMod) {
            reflectionModInstance = reflectionMod;
        }
    }
}