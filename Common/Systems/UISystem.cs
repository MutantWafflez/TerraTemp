using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using TerraTemp.Content.UI;

namespace TerraTemp.Common.Systems {

    /// <summary>
    /// System that handles all of the UI in the mod.
    /// </summary>
    [Autoload(Side = ModSide.Client)]
    public class UISystem : ModSystem {
        public GameTime lastGameTime;

        public ThermometerState thermometerUI;
        public UserInterface thermometerInterface;

        public ForecastState forecastUI;
        public UserInterface forecastInterface;

        public EnchantedBookshelfState enchantedBookshelfUI;
        public UserInterface enchantedBookshelfInterface;

        public override void Load() {
            thermometerUI = new ThermometerState();
            thermometerUI.Activate();
            thermometerInterface = new UserInterface();
            thermometerInterface.SetState(thermometerUI);

            forecastUI = new ForecastState();
            forecastUI.Activate();
            forecastInterface = new UserInterface();
            forecastInterface.SetState(null);

            enchantedBookshelfUI = new EnchantedBookshelfState();
            enchantedBookshelfUI.Activate();
            enchantedBookshelfInterface = new UserInterface();
            enchantedBookshelfInterface.SetState(null);
        }

        public override void UpdateUI(GameTime gameTime) {
            lastGameTime = gameTime;
            thermometerUI?.Update(gameTime);
            forecastUI?.Update(gameTime);
            enchantedBookshelfUI?.Update(gameTime);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) {
            int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
            if (resourceBarIndex != -1) {
                layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
                    $"{nameof(TerraTemp)}: Thermometer Display",
                    delegate {
                        if (lastGameTime != null) {
                            thermometerInterface.Draw(Main.spriteBatch, lastGameTime);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }

            int npcTalkIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: NPC / Sign Dialog"));
            if (npcTalkIndex != -1) {
                layers.Insert(npcTalkIndex + 1, new LegacyGameInterfaceLayer(
                    $"{nameof(TerraTemp)}: Weather Forecast",
                    delegate {
                        if (lastGameTime != null) {
                            forecastInterface.Draw(Main.spriteBatch, lastGameTime);
                        }

                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }

            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1) {
                layers.Insert(npcTalkIndex + 1, new LegacyGameInterfaceLayer(
                    $"{nameof(TerraTemp)}: Binding Interface",
                    delegate {
                        if (lastGameTime != null) {
                            enchantedBookshelfInterface.Draw(Main.spriteBatch, lastGameTime);
                        }

                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
    }
}