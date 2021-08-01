using Terraria;
using Terraria.ID;
using TerraTemp.Common.Players;
using TerraTemp.Content.Base.Items;

namespace TerraTemp.Content.Items.Accessories {

    public class HeterostaticRune : TempEquipment {

        public override float GetHeatComfortabilityChange(Player player) => -3f;

        public override float GetColdComfortabilityChange(Player player) => 3f;

        public override void SetDefaults() {
            Item.accessory = true;
            Item.width = 32;
            Item.height = 32;
            Item.value = Item.sellPrice(gold: 5);
            Item.rare = ItemRarityID.Yellow;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetModPlayer<AccessoryPlayer>().frostRune = true;
            player.GetModPlayer<AccessoryPlayer>().flameRune = true;
        }

        public override void AddRecipes() {
            CreateRecipe()
                .AddIngredient<FrostRune>()
                .AddIngredient<FlameRune>()
                .AddIngredient(ItemID.BrokenHeroSword)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}