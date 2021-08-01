using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraTemp.Content.Items.Miscellaneous {

    public class Thermometer : ModItem {

        public override void SetDefaults() {
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 1);
            Item.width = 32;
            Item.height = 32;
            Item.accessory = false;
        }

        public override void AddRecipes() {
            CreateRecipe()
                .AddIngredient(ItemID.Glass, 3)
                .AddIngredient(ItemID.WaterBucket)
                .AddRecipeGroup(RecipeGroupID.IronBar, 2)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}