using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Common.Players;
using TerraTemp.Content.Base.Items;

namespace TerraTemp.Content.Items.Accessories {

    public class FrostRune : TempEquipment {

        public override float GetHeatComfortabilityChange(Player player) => -3f;

        public override void SetDefaults() {
            item.accessory = true;
            item.width = 32;
            item.height = 32;
            item.value = Item.sellPrice(gold: 2);
            item.rare = ItemRarityID.LightRed;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetModPlayer<AccessoryPlayer>().frostRune = true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FrostCore);
            recipe.AddIngredient(ItemID.StoneBlock, 20);
            recipe.AddIngredient(ItemID.Shiverthorn, 3);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}