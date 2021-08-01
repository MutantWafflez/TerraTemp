using Terraria;
using Terraria.ID;
using TerraTemp.Common.Players;
using TerraTemp.Content.Base.Items;

namespace TerraTemp.Content.Items.Accessories {

    public class FlameRune : TempEquipment {

        public override float GetColdComfortabilityChange(Player player) => 3f;

        public override void SetDefaults() {
            Item.accessory = true;
            Item.width = 32;
            Item.height = 32;
            Item.value = Item.sellPrice(gold: 2);
            Item.rare = ItemRarityID.LightRed;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetModPlayer<AccessoryPlayer>().flameRune = true;
        }

        public override void AddRecipes() {
            CreateRecipe()
                .AddIngredient(ItemID.HellstoneBar, 10)
                .AddIngredient(ItemID.StoneBlock, 20)
                .AddIngredient(ItemID.Fireblossom, 3)
                .AddTile(TileID.Bookcases)
                .Register();
        }
    }
}