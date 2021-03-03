using System.ComponentModel;
using Terraria.ModLoader.Config;
using TerraTemp.Content.UI;

namespace TerraTemp.Common.Configs {

    [Label("Client Side")]
    public class TerraTempClientConfig : ModConfig {

        [Label("Thermometer UI Size")]
        [Tooltip("By what value to modify the size of the thermometer display UI. Defaults to 100% (normal size)")]
        [Range(0.5f, 1f)]
        [Increment(.25f)]
        [DrawTicks]
        [DefaultValue(1f)]
        public float thermometerUISize;

        public override ConfigScope Mode => ConfigScope.ClientSide;

        public override void OnChanged() {
            ThermometerState thermometerState = TerraTemp.Instance.thermometerUI;
            if (thermometerState != null) {
                thermometerState.thermometerFrame.ImageScale = thermometerUISize;
                thermometerState.thermometerLiquid.ImageScale = thermometerUISize;
            }
        }
    }
}