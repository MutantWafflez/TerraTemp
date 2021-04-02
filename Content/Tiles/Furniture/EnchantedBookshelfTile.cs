using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TerraTemp.Content.Items.Tiles.Furniture;
using TerraTemp.Content.Items.Tomes;

namespace TerraTemp.Content.Tiles.Furniture {

    public class EnchantedBookshelfTile : ModTile {

        public override void SetDefaults() {
            Main.tileFrameImportant[Type] = true;
            Main.tileWaterDeath[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileSolid[Type] = false;
            Main.tileSolidTop[Type] = true;
            Main.tileBlockLight[Type] = false;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
            TileObjectData.addTile(Type);

            minPick = 0;
            mineResist = 1.1f;

            AddMapEntry(new Color(255, 255, 0));
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY) {
            Item.NewItem(new Vector2(i * 16, j * 16), ModContent.ItemType<EnchantedBookshelf>());
        }

        public override bool NewRightClick(int i, int j) {
            if (TerraTemp.Instance.enchantedBookshelfInterface.CurrentState != TerraTemp.Instance.enchantedBookshelfUI) {
                TerraTemp.Instance.enchantedBookshelfInterface.SetState(TerraTemp.Instance.enchantedBookshelfUI);
                return true;
            }

            return false;
        }

        public override void MouseOver(int i, int j) {
            Player player = Main.LocalPlayer;

            bool hasATome = player.inventory.Any(item => item.type == ModContent.ItemType<FlameTome>() || item.type == ModContent.ItemType<FrostTome>());

            player.showItemIcon2 = player.inventory.Any(item => item.type == ModContent.ItemType<FlameTome>()) ? ModContent.ItemType<FlameTome>() : player.inventory.Any(item => item.type == ModContent.ItemType<FrostTome>()) ? ModContent.ItemType<FrostTome>() : 0;
            player.showItemIcon = hasATome;
            player.noThrow = 2;
        }
    }
}