using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Common.Players;

namespace TerraTemp.Content.Items.Accessories {
    public class FlameRune : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Flame Rune");
            Tooltip.SetDefault("2% increased damage and movement speed for each degree above normal body temperature"
                + "\n5 degree reduction in cold comfortability range");
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

    }
}
