using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using TerraTemp.Content.Items.Tomes;

namespace TerraTemp.Content.UI {

    public class EnchantedBookshelfState : UIState {
        public VanillaItemSlotWrapper armorItemSlot;
        public VanillaItemSlotWrapper tomeItemSlot;

        public override void OnInitialize() {
            armorItemSlot = new VanillaItemSlotWrapper(scale: 0.8f) {
                Left = { Pixels = 50 },
                Top = { Pixels = 270 },
                ValidItemFunc = item => item.modItem != null && item.wornArmor
            };
            tomeItemSlot = new VanillaItemSlotWrapper(scale: 0.8f) {
                Left = { Pixels = 100 },
                Top = { Pixels = 270 },
                ValidItemFunc = item => item.modItem is FrostTome || item.modItem is FlameTome
            };

            Append(armorItemSlot);
            Append(tomeItemSlot);
        }

        public override void OnActivate() {
            base.OnActivate();
            Main.PlaySound(SoundID.MenuOpen);

            Main.playerInventory = true;
            Main.HidePlayerCraftingMenu = true;
        }

        public override void OnDeactivate() {
            base.OnDeactivate();

            if (!armorItemSlot.Item.IsAir) {
                Main.LocalPlayer.QuickSpawnClonedItem(armorItemSlot.Item, armorItemSlot.Item.stack);
                armorItemSlot.Item.TurnToAir();
            }

            if (!tomeItemSlot.Item.IsAir) {
                Main.LocalPlayer.QuickSpawnClonedItem(tomeItemSlot.Item, tomeItemSlot.Item.stack);
                tomeItemSlot.Item.TurnToAir();
            }

            Main.PlaySound(SoundID.MenuClose);
        }
    }
}