using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using TerraTemp.Content.UI;

namespace TerraTemp.Common.Systems {

    public class UIHandlerSystem : ModSystem {
        internal GameTime lastGameTime;

        internal ThermometerState thermometerUI;
        internal UserInterface thermometerInterface;

        public static UIHandlerSystem UIHandlerSystemInstance {
            internal set;
            get;
        }

        public UIHandlerSystem() {
            UIHandlerSystemInstance = this;
        }

        public override void OnModLoad() {
            if (Main.netMode != NetmodeID.Server) {
                thermometerUI = new ThermometerState();
                thermometerUI.Activate();
                thermometerInterface = new UserInterface();
                thermometerInterface.SetState(thermometerUI);
            }
        }

        public override void Unload() {
            UIHandlerSystemInstance = null;
        }

        public override void UpdateUI(GameTime gameTime) {
            lastGameTime = gameTime;
            thermometerUI?.Update(gameTime);
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
        }
    }
}