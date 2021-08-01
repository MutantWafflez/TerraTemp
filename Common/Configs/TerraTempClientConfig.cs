﻿using System.ComponentModel;
using Terraria.ModLoader.Config;

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
            //TODO: Re-implement config functionality
            /*UISystem uiSystem = ModContent.GetInstance<UISystem>();

            ThermometerState thermometerState = uiSystem.thermometerUI;
            if (thermometerState != null) {
                thermometerState.thermometerFrame.ImageScale = thermometerUISize;
                thermometerState.thermometerLiquid.ImageScale = thermometerUISize;
            }*/
        }
    }
}