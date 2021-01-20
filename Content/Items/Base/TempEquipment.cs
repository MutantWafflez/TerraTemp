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
            temperaturePlayer.baseDesiredTemperature += DesiredTemperatureChange;
            temperaturePlayer.comfortableHigh += HeatComfortabilityChange;
            temperaturePlayer.comfortableLow += ColdComfortabilityChange;
            temperaturePlayer.temperatureChangeResist += TemperatureResistanceChange;
            temperaturePlayer.criticalRangeMaximum += CriticalTemperatureChange;
            temperaturePlayer.climateExtremityValue += ClimateExtremityChange;
        }
    }
}