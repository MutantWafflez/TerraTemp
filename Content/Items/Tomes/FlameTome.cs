﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Content.Items.Tomes {

    public class FlameTome : ModItem {
        public int tomeLevel;

        public FlameTome() {
            tomeLevel = 1;
        }

        public override ModItem Clone(Item item) {
            FlameTome clonedItem = (FlameTome)base.Clone(item);
            clonedItem.tomeLevel = tomeLevel;
            return clonedItem;
        }

        public override void SetDefaults() {
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(gold: 5);
            Item.material = true;
            Item.maxStack = 1;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips) {
            TooltipLine tomeLevelLine = new TooltipLine(Mod, "TomeLevel", LocalizationUtilities.GetTerraTempTextValue("MiscKeys.EnchantmentLevel", tomeLevel)) {
                overrideColor = Color.Orange
            };

            TooltipLine sellLine = tooltips.FirstOrDefault(tooltip => tooltip.mod == "Terraria" && (tooltip.Name == "Price" || tooltip.Name == "SpecialPrice"));
            if (sellLine != null) {
                tooltips.Insert(tooltips.IndexOf(sellLine), tomeLevelLine);
            }
            else {
                tooltips.Add(tomeLevelLine);
            }
        }

        public override void SaveData(TagCompound tag) {
            tag["Level"] = tomeLevel;
        }

        public override void LoadData(TagCompound tag) {
            tomeLevel = tag.GetInt("Level");
        }
    }
}