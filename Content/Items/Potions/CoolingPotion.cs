using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Content.Base.Items;
using TerraTemp.Content.Buffs.PotionEffects;
using TerraTemp.Content.Items.Materials.Fish;

namespace TerraTemp.Content.Items.Potions {

    public class CoolingPotion : TempItem {

        public override float GetHeatComfortabilityChange(Player player) => 8f;

        //Carbon copy opposite of Warmth Potion
        public override void SetDefaults() {
            Item.CloneDefaults(ItemID.WarmthPotion);
            Item.width = 32;
            Item.height = 32;
            Item.buffType = ModContent.BuffType<CoolingPotionBuff>();
        }

        public override void AddRecipes() {
            CreateRecipe()
                .AddIngredient(ItemID.BottledWater)
                .AddIngredient<BarbFish>()
                .AddIngredient(ItemID.Fireblossom)
                .AddTile(TileID.Bottles)
                .Register();
        }
    }
}