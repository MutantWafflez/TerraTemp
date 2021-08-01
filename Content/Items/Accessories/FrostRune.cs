using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Common.Players;
using TerraTemp.Content.Base.Items;

namespace TerraTemp.Content.Items.Accessories {

    public class FrostRune : TempEquipment {

        public override float GetHeatComfortabilityChange(Player player) => -3f;

        public override void SetDefaults() {
            Item.accessory = true;
            Item.width = 32;
            Item.height = 32;
            Item.value = Item.sellPrice(gold: 2);
            Item.rare = ItemRarityID.LightRed;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetModPlayer<AccessoryPlayer>().frostRune = true;
        }

        public override void AddRecipes() {
            CreateRecipe()
                .AddIngredient(ItemID.FrostCore)
                .AddIngredient(ItemID.StoneBlock, 20)
                .AddIngredient(ItemID.Shiverthorn, 3)
                .AddTile(TileID.Bookcases)
                .Register();
        }
    }
}