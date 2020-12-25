using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Common.Players;

namespace TerraTemp.Content.Items.Accessories {

    public class VolatileThermometer : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Volatile Thermometer");
            Tooltip.SetDefault("Relases a large explosion from either extreme heat or cold upon death");
        }

        public override void SetDefaults() {
            item.width = 30;
            item.height = 40;
            item.rare = ItemRarityID.Pink;
            item.value = Item.sellPrice(gold: 1);
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetModPlayer<AccessoryPlayer>().volatileThermometer = true;
        }
    }
}