using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using TerraTemp.Utilities;

namespace TerraTemp.Common.GlobalItems {
    /// <summary>
    /// GlobalItem class that handles all vanilla item changes for the mod.
    /// </summary>
    public class VanillaItemChanges : GlobalItem {

        //Vanilla Accessories/Armor, when equipped, give additional changes here
        public override void UpdateAccessory(Item item, Player player, bool hideVisual) {
            foreach (ItemChange change in TerraTemp.itemChanges) {
                if (item.type == change.AppliedItemID || change.ItemsThatContainThis.Contains(item.type)) {
                    TempPlayer temperaturePlayer = player.GetModPlayer<TempPlayer>();
                    temperaturePlayer.comfortableHigh += change.HeatComfortabilityChange;
                    temperaturePlayer.comfortableLow += change.ColdComfortabilityChange;
                    temperaturePlayer.temperatureChangeResist += change.TemperatureResistanceChange;
                    temperaturePlayer.criticalRangeMaximum += change.CriticalTemperatureChange;
                    break;
                }
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
            foreach (ItemChange change in TerraTemp.itemChanges) {
                if ((item.type == change.AppliedItemID || change.ItemsThatContainThis.Contains(item.type)) && change.AdditionalTooltip != null) {
                    TooltipLine newLine = new TooltipLine(mod, "TempAdditionalLine", change.AdditionalTooltip);
                    tooltips.Add(newLine);
                }
            }
        }
    }
}
