using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TerraTemp.Common.Players;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Common.GlobalItems {
    /// <summary>
    /// GlobalItem that handles all modded armors with enchantments on them, if applicable.
    /// </summary>
    public class EnchantedModdedItem : GlobalItem {
        public int flameEnchantmentLevel;
        public int frostEnchantmentLevel;

        public override bool InstancePerEntity => true;

        public EnchantedModdedItem() {
            flameEnchantmentLevel = 0;
            frostEnchantmentLevel = 0;
        }

        public override GlobalItem Clone(Item item, Item itemClone) {
            EnchantedModdedItem clonedItem = (EnchantedModdedItem)base.Clone(item, itemClone);
            clonedItem.flameEnchantmentLevel = flameEnchantmentLevel;
            clonedItem.frostEnchantmentLevel = frostEnchantmentLevel;
            return clonedItem;
        }

        public override void UpdateEquip(Item item, Player player) {
            TempPlayer tempPlayer = player.GetTempPlayer();

            tempPlayer.comfortableLow -= frostEnchantmentLevel;
            tempPlayer.comfortableHigh += flameEnchantmentLevel;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
            if (flameEnchantmentLevel != 0) {
                tooltips.Add(new TooltipLine(Mod, "FlameEnchantTip", LocalizationUtilities.GetTerraTempTextValue("MiscKeys.FlameEnchantment") + " " + flameEnchantmentLevel) {
                    OverrideColor = Color.Orange
                });
            }

            if (frostEnchantmentLevel != 0) {
                tooltips.Add(new TooltipLine(Mod, "FrostEnchantTip", LocalizationUtilities.GetTerraTempTextValue("MiscKeys.FrostEnchantment") + " " + frostEnchantmentLevel) {
                    OverrideColor = Color.Cyan
                });
            }
        }

        public override void SaveData(Item item, TagCompound tag) {
            tag["FlameLevel"] = flameEnchantmentLevel;
            tag["FrostLevel"] = frostEnchantmentLevel;
        }

        public override void LoadData(Item item, TagCompound tag) {
            flameEnchantmentLevel = tag.GetInt("FlameLevel");
            frostEnchantmentLevel = tag.GetInt("FrostLevel");
        }
    }
}