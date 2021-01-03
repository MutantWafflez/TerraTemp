using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Common.Players;

namespace TerraTemp.Content.Items.Accessories {

    public class HeterostaticRune : TempEquipment {
        public override float HeatComfortabilityChange => -5f;

        public override float ColdComfortabilityChange => 5f;

        public override void SetDefaults() {
            item.accessory = true;
            item.width = 32;
            item.height = 32;
            item.value = Item.sellPrice(gold: 5);
            item.rare = ItemRarityID.Yellow;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetModPlayer<AccessoryPlayer>().frostRune = true;
            player.GetModPlayer<AccessoryPlayer>().flameRune = true;
        }

        public override void AddRecipes() {
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