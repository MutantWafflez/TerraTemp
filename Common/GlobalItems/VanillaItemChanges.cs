using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Content.Changes;
using TerraTemp.Custom;

namespace TerraTemp.Common.GlobalItems {

    /// <summary>
    /// GlobalItem class that handles all vanilla item changes for the mod.
    /// </summary>
    public class VanillaItemChanges : GlobalItem {
        //Vanilla Accessories/Armor, when equipped, give additional changes here

        #region Additional Armor/Accessory Effects

        public override void UpdateEquip(Item item, Player player) {
            foreach (ItemChange itemChange in TerraTemp.itemChanges) {
                if (itemChange.AppliedItemIDs.Contains(item.type) &&
                    !player.GetTempPlayer().equippedItemChanges.Contains(itemChange) &&
                    (!(itemChange is DerivedItemChange) || !TempUtilities.ContainsList(player.GetTempPlayer().equippedItemChanges, (itemChange as DerivedItemChange).GetBaseItemChanges()))) {
                    TempPlayer temperaturePlayer = player.GetTempPlayer();
                    if (itemChange is DerivedItemChange) {
                        DerivedItemChange changeAsDerived = itemChange as DerivedItemChange;
                        foreach (ItemChange baseChange in changeAsDerived.GetBaseItemChanges()) {
                            temperaturePlayer.equippedItemChanges.Add(baseChange);
                        }
                    }
                    temperaturePlayer.equippedItemChanges.Add(itemChange);

                    temperaturePlayer.baseDesiredTemperature += itemChange.GetDesiredTemperatureChange(player);
                    temperaturePlayer.relativeHumidity += itemChange.GetHumidityChange(player);
                    temperaturePlayer.comfortableHigh += itemChange.GetHeatComfortabilityChange(player);
                    temperaturePlayer.comfortableLow += itemChange.GetColdComfortabilityChange(player);
                    temperaturePlayer.temperatureChangeResist += itemChange.GetTemperatureResistanceChange(player);
                    temperaturePlayer.criticalRangeMaximum += itemChange.GetCriticalTemperatureChange(player);
                    temperaturePlayer.climateExtremityValue += itemChange.GetClimateExtremityChange(player);
                    itemChange.AdditionalItemEquipEffect(player);
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
                    TooltipLine sellLine = tooltips.FirstOrDefault(tooltip => tooltip.mod == "Terraria" && (tooltip.Name == "Price" || tooltip.Name == "SpecialPrice"));

                    if (defenseLine != null) {
                        tooltips.Insert(tooltips.IndexOf(defenseLine) + 1, newLine);
                    }
                    else if (toolTipZero != null) {
                        tooltips.Insert(tooltips.IndexOf(toolTipZero) + 1, newLine);
                    }
                    else if (sellLine != null) {
                        tooltips.Insert(tooltips.IndexOf(sellLine), newLine);
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
            foreach (SetBonusChange setBonusChange in TerraTemp.setBonusChanges) {
                if (setBonusChange.ArmorSetName == set) {
                    TempPlayer temperaturePlayer = player.GetTempPlayer();
                    temperaturePlayer.baseDesiredTemperature += setBonusChange.GetDesiredTemperatureChange(player);
                    temperaturePlayer.relativeHumidity += setBonusChange.GetHumidityChange(player);
                    temperaturePlayer.comfortableHigh += setBonusChange.GetHeatComfortabilityChange(player);
                    temperaturePlayer.comfortableLow += setBonusChange.GetColdComfortabilityChange(player);
                    temperaturePlayer.temperatureChangeResist += setBonusChange.GetTemperatureResistanceChange(player);
                    temperaturePlayer.criticalRangeMaximum += setBonusChange.GetCriticalTemperatureChange(player);
                    temperaturePlayer.climateExtremityValue += setBonusChange.GetClimateExtremityChange(player);
                    player.setBonus += player.setBonus == "" ? setBonusChange.AdditionalSetBonusText : "\n" + setBonusChange.AdditionalSetBonusText;

                    setBonusChange.AdditionalSetBonusEffect(player);
                }
            }
        }

        #endregion
    }
}