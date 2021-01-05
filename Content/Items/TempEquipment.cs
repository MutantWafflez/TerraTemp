using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Items {

    /// <summary>
    /// Abstract class that extends ModItem that has built in functionality adding Equipment that
    /// changes temperature statistics.
    /// </summary>
    public abstract class TempEquipment : ModItem {

        /// <summary>
        /// By how much this given item will change the player's Base Desired (Environmental) Temperature.
        /// </summary>
        public virtual float DesiredTemperatureChange => 0f;

        /// <summary>
        /// By how much this given item will change the player's Heat Comfortability Range.
        /// </summary>
        public virtual float HeatComfortabilityChange => 0f;

        /// <summary>
        /// By how much this given item will change the player's Cold Comfortability Range.
        /// </summary>
        public virtual float ColdComfortabilityChange => 0f;

        /// <summary>
        /// By how much this given item will change the player's Temperature Resistance.
        /// </summary>
        public virtual float TemperatureResistanceChange => 0f;

        /// <summary>
        /// By how much this given item will change the player's critical temperature range.
        /// </summary>
        public virtual float CriticalTemperatureChange => 0f;

        public override void ModifyTooltips(List<TooltipLine> tooltips) {
            string returnedLine = TempUtilities.CreateNewLineBasedOnStats(HeatComfortabilityChange, ColdComfortabilityChange, TemperatureResistanceChange, CriticalTemperatureChange, DesiredTemperatureChange);
            if (returnedLine != null) {
                TooltipLine modifierLine = tooltips.FirstOrDefault(t => t.mod == "Terraria" && t.Name.Contains("Prefix"));
                if (modifierLine != null) {
                    tooltips.Insert(tooltips.IndexOf(modifierLine), new TooltipLine(mod, "TemperatureStatChange", returnedLine));
                }
                else {
                    tooltips.Add(new TooltipLine(mod, "TemperatureStatChange", returnedLine));
                }
            }
        }

        public override void UpdateEquip(Player player) {
            TempPlayer temperaturePlayer = player.GetTempPlayer();
            temperaturePlayer.baseDesiredTemperature += DesiredTemperatureChange;
            temperaturePlayer.comfortableHigh += HeatComfortabilityChange;
            temperaturePlayer.comfortableLow += ColdComfortabilityChange;
            temperaturePlayer.temperatureChangeResist += TemperatureResistanceChange;
            temperaturePlayer.criticalRangeMaximum += CriticalTemperatureChange;
        }
    }
}