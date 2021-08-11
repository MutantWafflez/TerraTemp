using Terraria;
using TerraTemp.Common.Players;
using TerraTemp.Custom.Interfaces;

namespace TerraTemp.Custom.Utilities {

    /// <summary>
    /// Class that holds methods dealing with players.
    /// </summary>
    public static class PlayerUtilities {

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
    }
}