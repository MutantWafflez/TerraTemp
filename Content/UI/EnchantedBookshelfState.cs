using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using TerraTemp.Common.GlobalItems;
using TerraTemp.Content.Items.Tomes;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Content.UI {
    public class EnchantedBookshelfState : UIState {
        public VanillaItemSlotWrapper armorItemSlot;
        public VanillaItemSlotWrapper tomeItemSlot;
        public UIImage bindButton;

        public bool playedHoverTick;

        //We don't want to allow binding of tomes that have the same level or lower to armor that already has a bound enchantment, which is where this check comes into play
        public bool IsValidBinding {
            get {
                if (armorItemSlot.Item.type == ItemID.None || tomeItemSlot.Item.type == ItemID.None) {
                    return false;
                }
                //True = Flame, False = Frost
                bool tomeType = tomeItemSlot.Item.ModItem is FlameTome;

                return tomeType
                    ? armorItemSlot.Item.GetGlobalItem<EnchantedModdedItem>().flameEnchantmentLevel < ((FlameTome)tomeItemSlot.Item.ModItem).tomeLevel
                    : armorItemSlot.Item.GetGlobalItem<EnchantedModdedItem>().frostEnchantmentLevel < ((FrostTome)tomeItemSlot.Item.ModItem).tomeLevel;
            }
        }

        public override void OnInitialize() {
            armorItemSlot = new VanillaItemSlotWrapper(scale: 0.8f) {
                Left = { Pixels = 116 },
                Top = { Pixels = 260 },
                //Usually the bool "wornArmor" is set to true for armor sets, but some mods don't se the bool correctly since it's not *vital* for functionality
                //Thus, since an overwhelming majority of armors change the head/body/leg slot, these additional checks are here in case wornArmor isn't set
                ValidItemFunc = item => item.ModItem != null && (item.wornArmor || item.headSlot != -1 || item.bodySlot != -1 || item.legSlot != -1)
            };
            tomeItemSlot = new VanillaItemSlotWrapper(scale: 0.8f) {
                Left = { Pixels = 212 },
                Top = { Pixels = 260 },
                //Only allow our modded tomes in this slot
                ValidItemFunc = item => item.ModItem is FrostTome or FlameTome
            };
            bindButton = new UIImage(TextureAssets.Item[ItemID.SpellTome]) {
                Left = { Pixels = 170 },
                Top = { Pixels = 268 }
            };

            Append(armorItemSlot);
            Append(tomeItemSlot);
            Append(bindButton);
        }

        public override void OnActivate() {
            base.OnActivate();
            SoundEngine.PlaySound(SoundID.MenuOpen);

            Main.playerInventory = true;
            Main.hidePlayerCraftingMenu = true;
        }

        public override void OnDeactivate() {
            base.OnDeactivate();

            //Return items to player if UI is closed with items in the slots
            if (!armorItemSlot.Item.IsAir) {
                Main.LocalPlayer.QuickSpawnClonedItem(new EntitySource_Misc("UIClose"), armorItemSlot.Item, armorItemSlot.Item.stack);
                armorItemSlot.Item.TurnToAir();
            }

            if (!tomeItemSlot.Item.IsAir) {
                Main.LocalPlayer.QuickSpawnClonedItem(new EntitySource_Misc("UIClose"), tomeItemSlot.Item, tomeItemSlot.Item.stack);
                tomeItemSlot.Item.TurnToAir();
            }

            SoundEngine.PlaySound(SoundID.MenuClose);
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            //If there are items in the slots, the items can be bound, and the player is clicking, properly apply the enchantment and destroy the tome in the process
            if (Main.mouseLeft && bindButton.ContainsPoint(Main.MouseScreen) && armorItemSlot.Item.type != ItemID.None && tomeItemSlot.Item.type != ItemID.None && IsValidBinding) {
                if (tomeItemSlot.Item.ModItem.GetType() == typeof(FlameTome)) {
                    armorItemSlot.Item.GetGlobalItem<EnchantedModdedItem>().flameEnchantmentLevel = ((FlameTome)tomeItemSlot.Item.ModItem).tomeLevel;
                }
                else {
                    armorItemSlot.Item.GetGlobalItem<EnchantedModdedItem>().frostEnchantmentLevel = ((FrostTome)tomeItemSlot.Item.ModItem).tomeLevel;
                }

                tomeItemSlot.Item.TurnToAir();
                CombatText.NewText(new Rectangle((int)Main.LocalPlayer.position.X, (int)Main.LocalPlayer.Bottom.Y, 15, 1), Color.Yellow, LocalizationUtilities.GetTerraTempTextValue("UIInfo.SuccessfulBind"), true);
                SoundEngine.PlaySound(SoundID.Item119);
            }
        }

        protected override void DrawChildren(SpriteBatch spriteBatch) {
            base.DrawChildren(spriteBatch);

            if (bindButton.ContainsPoint(Main.MouseScreen)) {
                if (!playedHoverTick) {
                    SoundEngine.PlaySound(SoundID.MenuTick);
                    playedHoverTick = true;
                }

                //Drawing of the outline around the tome icon similar to the vanilla reforge icon
                Asset<Texture2D> highlightTexture = ModContent.Request<Texture2D>(TerraTemp.TextureDirectory + "UI/TomeOutline");
                spriteBatch.Draw(highlightTexture.Value, new Vector2(bindButton.Left.Pixels - 2f, bindButton.Top.Pixels - 4f), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

                if (IsValidBinding) {
                    Main.instance.MouseText(LocalizationUtilities.GetTerraTempTextValue("UIInfo.BindHover"));
                }
                else {
                    Main.instance.MouseText(LocalizationUtilities.GetTerraTempTextValue("UIInfo.InvalidBind"), ItemRarityID.Red);
                }

                Main.LocalPlayer.mouseInterface = true;
            }
            else {
                playedHoverTick = false;
            }

            //Draw armor background visual to tell the player what slot is for armor pieces
            if (armorItemSlot.Item.type == ItemID.None) {
                Asset<Texture2D> armorVisual = ModContent.Request<Texture2D>("Terraria/UI/DisplaySlots_0");
                spriteBatch.Draw(armorVisual.Value, new Vector2(armorItemSlot.Left.Pixels + 7.75f, armorItemSlot.Top.Pixels + 9f), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
        }
    }
}