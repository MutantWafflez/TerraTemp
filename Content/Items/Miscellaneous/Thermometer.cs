using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraTemp.Content.Items.Miscellaneous {

    public class Thermometer : ModItem {

        public override void SetDefaults() {
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(silver: 1);
            item.width = 32;
            item.height = 32;
            item.accessory = false;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Glass, 3);
            recipe.AddIngredient(ItemID.WaterBucket, 1);
            recipe.AddRecipeGroup("IronBar", 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}