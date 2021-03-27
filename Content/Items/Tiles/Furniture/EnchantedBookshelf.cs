using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Content.Tiles.Furniture;

namespace TerraTemp.Content.Items.Tiles.Furniture {

    public class EnchantedBookshelf : ModItem {

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.ObsidianBookcase);
            item.rare = ItemRarityID.Blue;
            item.placeStyle = 0;
            item.createTile = ModContent.TileType<EnchantedBookshelfTile>();
            item.value = Item.buyPrice(gold: 5);
        }
    }
}