using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Content.Changes;

namespace TerraTemp.Common.GlobalItems {

    /// <summary>
    /// GlobalItem class that handles all vanilla item changes for the mod.
    /// </summary>
    public class VanillaItemChanges : GlobalItem {
        //Vanilla Accessories/Armor, when equipped, give additional changes here

        #region Additional Armor/Accessory Effects

        public override void UpdateEquip(Item item, Player player) {
            foreach (ItemChange change in TerraTemp.itemChanges) {
                if (change.AppliedItemIDs.Contains(item.type)) {
                    TempPlayer temperaturePlayer = player.GetModPlayer<TempPlayer>();
                    temperaturePlayer.baseDesiredTemperature += change.DesiredTemperatureChange;
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
                if (change.AppliedItemIDs.Contains(item.type) && !item.social && change.AdditionalTooltip != null) {
                    TooltipLine newLine = new TooltipLine(mod, "TempAdditionalLine", change.AdditionalTooltip);

                    //These checks are so the new tooltips are placed properly and follow the normal formatting of vanilla tooltips.
                    TooltipLine toolTipZero = tooltips.FirstOrDefault(t => t.mod == "Terraria" && t.Name == "Tooltip0");
                    TooltipLine defenseLine = tooltips.FirstOrDefault(t => t.mod == "Terraria" && t.Name == "Defense");

                    if (defenseLine != null) {
                        tooltips.Insert(tooltips.IndexOf(defenseLine) + 1, newLine);
                    }
                    else if (toolTipZero != null) {
                        tooltips.Insert(tooltips.IndexOf(toolTipZero) + 1, newLine);
                    }
                    else {
                        tooltips.Add(newLine);
                    }
                }
            }
        }

        #endregion

        //Vanilla Armor can have additional set bonus effects, handled here

        #region Additional Set Bonus Effects

        public override string IsArmorSet(Item head, Item body, Item legs) {
            foreach (SetBonusChange change in TerraTemp.setBonusChanges) {
                if (change.HelmetPieceID.Contains(head.type) && change.ChestPieceID == body.type && (change.LegPieceID == legs.type || (change.LegPieceID == -1 && legs.type == ItemID.None)) /* this check is for the possible armor sets with no leggings */) {
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
                    temperaturePlayer.baseDesiredTemperature += change.DesiredTemperatureChange;
                    temperaturePlayer.comfortableHigh += change.HeatComfortabilityChange;
                    temperaturePlayer.comfortableLow += change.ColdComfortabilityChange;
                    temperaturePlayer.temperatureChangeResist += change.TemperatureResistanceChange;
                    temperaturePlayer.criticalRangeMaximum += change.CriticalTemperatureChange;
                    player.setBonus += player.setBonus == "" ? change.AdditionalSetBonusText : "\n" + change.AdditionalSetBonusText;

                    change.AdditionalSetBonusEffect(player);
                }
            }
        }

        #endregion
    }
}