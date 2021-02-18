using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Common.Players;

namespace TerraTemp.Content.Items.Accessories {

    public class VolatileThermometer : ModItem {

        public override void SetDefaults() {
            Item.width = 30;
            Item.height = 40;
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(gold: 1);
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetModPlayer<AccessoryPlayer>().volatileThermometer = true;
        }
    }
}