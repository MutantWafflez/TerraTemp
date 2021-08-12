using System;
using System.Collections.Generic;
using System.Linq;
using IL.Terraria.GameContent.ItemDropRules;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Common.Players;
using TerraTemp.Common.Systems;
using TerraTemp.Content.Changes;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Common.GlobalItems {

    /// <summary>
    /// GlobalItem class that handles all vanilla item changes for the mod.
    /// </summary>
    public class VanillaItemChanges : GlobalItem {

        //Vanilla Accessories/Armor, when equipped, give additional changes here
        public override void UpdateEquip(Item item, Player player) {
            foreach (ItemChange itemChange in ContentListSystem.itemChanges) {
                if ((itemChange.AppliedItemIDs.Contains(item.type) || itemChange.InheritedItemIDs.Any(pair => pair.Item2 == item.type)) && !player.GetTempPlayer().equippedItemChanges.Contains(itemChange)) {
                    TempPlayer temperaturePlayer = player.GetTempPlayer();
                    temperaturePlayer.equippedItemChanges.Add(itemChange);

                    PlayerUtilities.ApplyStatChanges(itemChange, player);

                    itemChange.AdditionalItemEquipEffect(player);
                }
            }
        }

        //Tooltip updating dealt here:
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
            foreach (ItemChange itemChange in ContentListSystem.itemChanges) {
                if (item.social || itemChange.AdditionalTooltip == null) {
                    continue;
                }

                Tuple<int, int> possibleInheritor = itemChange.InheritedItemIDs.FirstOrDefault(tuple => tuple.Item2 == item.type);

                if (itemChange.AppliedItemIDs.Contains(item.type)) {
                    TooltipLine newLine = new TooltipLine(Mod, "TempAdditionalLine", itemChange.AdditionalTooltip);

                    //These checks are so the new tooltips are placed properly and follow the normal formatting of vanilla tooltips.
                    TooltipLine toolTipZero = tooltips.FirstOrDefault(t => t.mod == "Terraria" && t.Name == "Tooltip0");
                    TooltipLine defenseLine = tooltips.FirstOrDefault(t => t.mod == "Terraria" && t.Name == "Defense");
                    TooltipLine sellLine = tooltips.FirstOrDefault(tooltip => tooltip.mod == "Terraria" && (tooltip.Name is "Price" or "SpecialPrice"));

                    //All these checks force the inherited lines to go to the bottom, regardless of the item's tooltip
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

                if (possibleInheritor != null) {
                    //Adds the item icon of the Item ID this item is inheriting from to the end of the tooltip
                    //Adjusts based on whether or not the tooltip is multiple lines or not, if the benefactor ID has multiple effects
                    TooltipLine newLine = new TooltipLine(Mod,
                        "TempAdditionalLine",
                        itemChange.AdditionalTooltip.Contains("\n")
                            ? itemChange.AdditionalTooltip.Replace("\n", $" [i:{possibleInheritor.Item1}]\n") + $" [i:{possibleInheritor.Item1}]"
                            : itemChange.AdditionalTooltip + $" [i:{possibleInheritor.Item1}]");

                    //In the case of the inherited item list, we want the tooltips to be at the bottom of the list, but above the sellLine if being sold.
                    TooltipLine sellLine = tooltips.FirstOrDefault(tooltip => tooltip.mod == "Terraria" && (tooltip.Name is "Price" or "SpecialPrice"));

                    if (sellLine != null) {
                        tooltips.Insert(tooltips.IndexOf(sellLine), newLine);
                    }
                    else {
                        tooltips.Add(newLine);
                    }
                }
            }

            foreach (ItemHoldoutChange itemHoldoutChange in ContentListSystem.itemHoldoutChanges) {
                if (itemHoldoutChange.AppliedItemIDs.Contains(item.type) && !item.social && itemHoldoutChange.AdditionalTooltip != null) {
                    TooltipLine newLine = new TooltipLine(Mod, "TempAdditionalLine", itemHoldoutChange.AdditionalTooltip);

                    //These checks are so the new tooltips are placed properly and follow the normal formatting of vanilla tooltips.
                    TooltipLine toolTipZero = tooltips.FirstOrDefault(t => t.mod == "Terraria" && t.Name == "Tooltip0");
                    TooltipLine defenseLine = tooltips.FirstOrDefault(t => t.mod == "Terraria" && t.Name == "Defense");
                    TooltipLine sellLine = tooltips.FirstOrDefault(tooltip => tooltip.mod == "Terraria" && (tooltip.Name is "Price" or "SpecialPrice"));

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

        //Vanilla Armor can have additional set bonus effects, handled here

        #region Additional Set Bonus Effects

        public override string IsArmorSet(Item head, Item body, Item legs) {
            foreach (SetBonusChange change in ContentListSystem.setBonusChanges) {
                if (change.HelmetPieceID.Contains(head.type) && change.ChestPieceID == body.type && (change.LegPieceID == legs.type || (change.LegPieceID == -1 && legs.type == ItemID.None)) /* this check is for the possible armor sets with no leggings */) {
                    if (change.ArmorSetName == null) {
                        throw new ArgumentNullException("ArmorSetName in change named " + change + " is null, and cannot be null.");
                    }
                    return change.ArmorSetName;
                }
            }
            return base.IsArmorSet(head, body, legs);
        }

        public override void UpdateArmorSet(Player player, string set) {
            foreach (SetBonusChange setBonusChange in ContentListSystem.setBonusChanges) {
                if (setBonusChange.ArmorSetName == set) {
                    PlayerUtilities.ApplyStatChanges(setBonusChange, player);

                    player.setBonus += player.setBonus == "" ? setBonusChange.AdditionalSetBonusText : "\n" + setBonusChange.AdditionalSetBonusText;

                    setBonusChange.AdditionalSetBonusEffect(player);
                }
            }
        }

        #endregion
    }
}