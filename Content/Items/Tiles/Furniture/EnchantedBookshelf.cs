using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Content.Tiles.Furniture;

namespace TerraTemp.Content.Items.Tiles.Furniture {

    public class EnchantedBookshelf : ModItem {

        public override void SetDefaults() {
            Item.CloneDefaults(ItemID.ObsidianBookcase);
            Item.rare = ItemRarityID.Blue;
            Item.placeStyle = 0;
            Item.createTile = ModContent.TileType<EnchantedBookshelfTile>();
            Item.value = Item.buyPrice(gold: 5);
        }
    }
}