using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Content.Buffs.PotionEffects;
using TerraTemp.Content.Items.Materials.Fish;
using TerraTemp.Custom;

namespace TerraTemp.Content.Items.Potions {

    public class CoolingPotion : ModItem {

        //Carbon copy opposite of Warmth Potion
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Cooling Potion");
            Tooltip.SetDefault(TempUtilities.GetTerraTempTextValue("GlobalTooltip.IncreasedHeatComfortability", 8f));
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.WarmthPotion);
            item.width = 32;
            item.height = 32;
            item.buffType = ModContent.BuffType<CoolingPotionBuff>();
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ModContent.ItemType<BarbFish>());
            recipe.AddIngredient(ItemID.Fireblossom);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}