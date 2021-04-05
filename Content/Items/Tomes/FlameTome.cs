using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TerraTemp.Custom;

namespace TerraTemp.Content.Items.Tomes {

    public class FlameTome : ModItem {
        public int tomeLevel;

        public override bool CloneNewInstances => true;

        public FlameTome() {
            tomeLevel = 1;
        }

        public override ModItem Clone(Item item) {
            FlameTome clonedItem = (FlameTome)base.Clone(item);
            clonedItem.tomeLevel = tomeLevel;
            return clonedItem;
        }

        public override void SetDefaults() {
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(gold: 5);
            item.material = true;
            item.maxStack = 1;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips) {
            TooltipLine tomeLevelLine = new TooltipLine(mod, "TomeLevel", TempUtilities.GetTerraTempTextValue("MiscKeys.EnchantmentLevel", tomeLevel)) {
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

        public override TagCompound Save() {
            return new TagCompound {
                {"Level", tomeLevel}
            };
        }

        public override void Load(TagCompound tag) {
            tomeLevel = tag.GetInt("Level");
        }
    }
}