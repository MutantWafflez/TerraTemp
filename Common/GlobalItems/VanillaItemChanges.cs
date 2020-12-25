using System.Collections.Generic;
using System.Linq;
using System;
using Terraria;
using Terraria.ModLoader;
using TerraTemp.Content.Changes;

namespace TerraTemp.Common.GlobalItems {

    /// <summary>
    /// GlobalItem class that handles all vanilla item changes for the mod.
    /// </summary>
    public class VanillaItemChanges : GlobalItem {

        //Vanilla Accessories/Armor, when equipped, give additional changes here
        public override void UpdateEquip(Item item, Player player) {
            foreach (ItemChange change in TerraTemp.itemChanges) {
                if (item.type == change.AppliedItemID || change.AlternativeIDs.Contains(item.type)) {
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
                if ((item.type == change.AppliedItemID || change.AlternativeIDs.Contains(item.type)) && change.AdditionalTooltip != null) {
                    TooltipLine newLine = new TooltipLine(mod, "TempAdditionalLine", change.AdditionalTooltip);
                    TooltipLine materialLine = tooltips.FirstOrDefault(t => t.mod == "Terraria" && t.Name == "Material");
                    if (materialLine != null && materialLine == tooltips.Last()) {
                        tooltips.Insert(tooltips.IndexOf(materialLine), newLine);
                    }
                    else {
                        tooltips.Add(newLine);
                    }
                }
            }
        }

        public override string IsArmorSet(Item head, Item body, Item legs) {
            foreach (SetBonusChange change in TerraTemp.setBonusChanges) {
                if (change.HelmetPieceID == head.type && change.ChestPieceID == body.type && change.LegPieceID == legs.type) {
                    if (change.ArmorSetName == null) {
                        throw new ArgumentNullException("ArmorSetName in change named " + change.ToString() + " is null, and cannot be null.");
                    }
                    return change.ArmorSetName;
                }
            }
            return base.IsArmorSet(head, body, legs);
        }

        public override void UpdateArmorSet(Player player, string set) {
            foreach (SetBonusChange change in TerraTemp.setBonusChanges) {
                if (change.ArmorSetName == set) {
                    TempPlayer temperaturePlayer = player.GetModPlayer<TempPlayer>();
                    temperaturePlayer.comfortableHigh += change.HeatComfortabilityChange;
                    temperaturePlayer.comfortableLow += change.ColdComfortabilityChange;
                    temperaturePlayer.temperatureChangeResist += change.TemperatureResistanceChange;
                    temperaturePlayer.criticalRangeMaximum += change.CriticalTemperatureChange;
                    player.setBonus += player.setBonus == "" ? change.AdditionalSetBonusText : "\n" + change.AdditionalSetBonusText;
                }
            }
        }
    }
}