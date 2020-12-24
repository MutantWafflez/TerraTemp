using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Common.Players;

namespace TerraTemp.Content.Items.Accessories
{
    public class HeterostaticRune : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heterostatic Rune");
            Tooltip.SetDefault("2% increased damage and movement speed for each degree above normal body temperature"
                + "\n2% increased defense and damage reduction for each degree below normal body temperature"
                + "\n5 degree reduction in comfortable range");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 32;
            item.height = 32;
            item.value = Item.sellPrice(gold: 5);
            item.rare = ItemRarityID.Yellow;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AccessoryPlayer>().frostRune = true;
            player.GetModPlayer<AccessoryPlayer>().flameRune = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<FrostRune>());
            recipe.AddIngredient(ModContent.ItemType<FlameRune>());
            recipe.AddIngredient(ItemID.BrokenHeroSword);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
