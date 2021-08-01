using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraTemp.Content.Items.Materials.Fish {

    public class BarbFish : ModItem {

        public override void SetDefaults() {
            Item.maxStack = 999;
            Item.value = Item.sellPrice(silver: 1);
            Item.rare = ItemRarityID.Blue;
            Item.width = 34;
            Item.height = 34;
        }

        public override void CaughtFishStack(ref int stack) {
            stack = 1;
        }
    }
}