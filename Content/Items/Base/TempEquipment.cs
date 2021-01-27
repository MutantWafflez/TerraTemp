using Terraria;
using TerraTemp.Custom;

namespace TerraTemp.Content.Base.Items {

    /// <summary>
    /// Abstract class that extends TempItem that has built in functionality adding Equipment that
    /// changes temperature statistics.
    /// </summary>
    public abstract class TempEquipment : TempItem {

        public override void UpdateEquip(Player player) {
            TempPlayer temperaturePlayer = player.GetTempPlayer();
            temperaturePlayer.baseDesiredTemperature += GetDesiredTemperatureChange(player);
            temperaturePlayer.comfortableHigh += GetHeatComfortabilityChange(player);
            temperaturePlayer.comfortableLow += GetColdComfortabilityChange(player);
            temperaturePlayer.temperatureChangeResist += GetTemperatureResistanceChange(player);
            temperaturePlayer.criticalRangeMaximum += GetCriticalTemperatureChange(player);
            temperaturePlayer.climateExtremityValue += GetClimateExtremityChange(player);
        }
    }
}