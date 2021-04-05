using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace TerraTemp.Content.Items.Tomes {

    public class FrostTome : ModItem {
        public int tomeLevel;

        public override bool CloneNewInstances => true;

        public FrostTome() {
            tomeLevel = 1;
        }

        public override ModItem Clone(Item item) {
            FrostTome clonedItem = (FrostTome)base.Clone(item);
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
            TooltipLine tomeLevelLine = new TooltipLine(mod, "TomeLevel", "Level " + tomeLevel) {
                overrideColor = Color.Cyan
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