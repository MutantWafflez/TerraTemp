using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraTemp.Content.Items.Materials.Fish {

    public class BarbFish : ModItem {

        public override void SetDefaults() {
            item.maxStack = 999;
            item.value = Item.sellPrice(silver: 1);
            item.rare = ItemRarityID.Blue;
            item.width = 34;
            item.height = 34;
        }

        public override void CaughtFishStack(ref int stack) {
            stack = 1;
        }
    }
}