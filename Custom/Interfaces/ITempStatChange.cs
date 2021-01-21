using Terraria;

namespace TerraTemp.Custom.Interfaces {

    /// <summary>
    /// Interface that is applicable for any class that handles the changing of a given player's
    /// temperature statistics.
    /// </summary>
    public interface ITempStatChange {

        /// <summary>
        /// By how much this given change will change the player's Base Desired (Environmental) Temperature.
        /// </summary>
        float GetDesiredTemperatureChange(Player player);

        /// <summary>
        /// By how much this given item will change the player's Relative Humidity.
        /// </summary>
        float GetHumidityChange(Player player);

        /// <summary>
        /// By how much this given change will change the player's Heat Comfortability Range.
        /// </summary>
        float GetHeatComfortabilityChange(Player player);

        /// <summary>
        /// By how much this given change will change the player's Cold Comfortability Range.
        /// </summary>
        float GetColdComfortabilityChange(Player player);

        /// <summary>
        /// By how much this given change will change the player's Temperature Resistance.
        /// </summary>
        float GetTemperatureResistanceChange(Player player);

        /// <summary>
        /// By how much this given change will change the player's critical temperature range.
        /// </summary>
        float GetCriticalTemperatureChange(Player player);

        /// <summary>
        /// By how much this given change will change the player's climate extremity value.
        /// </summary>
        float GetClimateExtremityChange(Player player);
    }
}