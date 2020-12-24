using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerraTemp.Common.Players;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Items.Accessories {

    public class FlameRune : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Flame Rune");
            Tooltip.SetDefault("2% increased damage and movement speed for each degree above normal body temperature"
                + "\n" + TempUtilities.GetTerraTempTextValue("GlobalTooltip.DecreasedColdComfortability", 5));
        }

        public override void SetDefaults() {
            item.accessory = true;
            item.width = 32;
            item.height = 32;
            item.value = Item.sellPrice(gold: 2);
            item.rare = ItemRarityID.LightRed;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetModPlayer<AccessoryPlayer>().flameRune = true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddIngredient(ItemID.StoneBlock, 20);
            recipe.AddIngredient(ItemID.Fireblossom, 3);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}