using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.UI;

namespace TerraTemp.Content.UI {

    /// <summary>
    /// Handy wrapper class that has the basic functionality of an item slot in vanilla. Code is
    /// courtesy of Example Mod with a few tweaks, thanks tML team!
    /// </summary>
    public class VanillaItemSlotWrapper : UIElement {
        public Item Item;
        public Func<Item, bool> ValidItemFunc;
        private readonly int slotContext;
        private readonly float slotScale;

        public VanillaItemSlotWrapper(int context = ItemSlot.Context.BankItem, float scale = 1f) {
            slotContext = context;
            slotScale = scale;
            Item = new Item();
            Item.SetDefaults(0);

            Width.Set(Main.inventoryBack9Texture.Width * scale, 0f);
            Height.Set(Main.inventoryBack9Texture.Height * scale, 0f);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch) {
            float oldScale = Main.inventoryScale;
            Main.inventoryScale = slotScale;
            Rectangle rectangle = GetDimensions().ToRectangle();

            //Draw the item's name in the slot in the proper rarity if there is an item present and the player isn't holding any item on their mouse
            if (ContainsPoint(Main.MouseScreen) && Main.mouseItem.type == ItemID.None && Item.type != ItemID.None) {
                Main.instance.MouseText(Item.HoverName, Item.rare);
            }

            if (ContainsPoint(Main.MouseScreen) && !PlayerInput.IgnoreMouseInterface) {
                Main.LocalPlayer.mouseInterface = true;
                //IsAir Check is here so that the click will still function with an empty mouse, so that the player can pick up the item from the slot
                if (ValidItemFunc == null || ValidItemFunc(Main.mouseItem) || Main.mouseItem.IsAir) {
                    // Handle handles all the click and hover actions based on the context.
                    ItemSlot.Handle(ref Item, slotContext);
                }
            }

            // Draw draws the slot itself and Item. Depending on context, the color will change, as
            // will drawing other things like stack counts.
            ItemSlot.Draw(spriteBatch, ref Item, slotContext, rectangle.TopLeft());
            Main.inventoryScale = oldScale;
        }
    }
}