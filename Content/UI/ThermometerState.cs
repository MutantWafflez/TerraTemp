using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;
using TerraTemp.Common.Configs;
using TerraTemp.Content.Items.Miscellaneous;
using TerraTemp.Custom;

namespace TerraTemp.Content.UI {

    /// <summary>
    /// UI class that handles the UI for the Thermometer item.
    /// </summary>
    public class ThermometerState : UIState {
        public ThermometerDraggableElement draggableElement;
        public UIImage thermometerFrame;
        public UIText temperatureReading;
        public ColorableUIImage thermometerLiquid;

        public override void OnInitialize() {
            thermometerFrame = new UIImage(ModContent.GetTexture(TempUtilities.TEXTURE_DIRECTORY + "UI/ThermometerFrame")) {
                ImageScale = ModContent.GetInstance<TerraTempClientConfig>().thermometerUISize
            };

            draggableElement = new ThermometerDraggableElement();
            draggableElement.Width.Set(thermometerFrame.Width.Pixels, 0f);
            draggableElement.Height.Set(thermometerFrame.Height.Pixels, 0f);
            draggableElement.Left.Set(0f, 0f);
            draggableElement.Top.Set(-thermometerFrame.Height.Pixels, 1f);
            draggableElement.Append(thermometerFrame);

            thermometerLiquid = new ColorableUIImage(ModContent.GetTexture(TempUtilities.TEXTURE_DIRECTORY + "UI/ThermometerLiquid")) {
                ImageScale = ModContent.GetInstance<TerraTempClientConfig>().thermometerUISize
            };
            draggableElement.Append(thermometerLiquid);

            temperatureReading = new UIText("50\u00B0C");
            temperatureReading.Left.Set(0, 0.25f);
            temperatureReading.Top.Set(0, 0.675f);
            draggableElement.Append(temperatureReading);

            Append(draggableElement);
        }

        protected override void DrawChildren(SpriteBatch spriteBatch) {
            //Don't draw without the Thermometer Item within the inventory/piggy bank
            if (!Main.LocalPlayer.inventory.Any(item => item.type == ModContent.ItemType<Thermometer>()) && !Main.LocalPlayer.bank.item.Any(item => item.type == ModContent.ItemType<Thermometer>())) {
                return;
            }

            base.DrawChildren(spriteBatch);

            TempPlayer temperaturePlayer = Main.LocalPlayer.GetTempPlayer();

            //Check/Apply for potential Image Scale change
            float uiSize = ModContent.GetInstance<TerraTempClientConfig>().thermometerUISize;
            float recalculatedLiquidPosition = (1f - uiSize) / 2f;
            float recalculatedReadingPosition = 0.675f - (1f - uiSize) / 10f;
            thermometerLiquid.ImageScale = uiSize;
            thermometerLiquid.Left.Set(0, recalculatedLiquidPosition);
            thermometerLiquid.Top.Set(0, recalculatedLiquidPosition);
            temperatureReading.Top.Set(0, recalculatedReadingPosition);

            //Update temperature reading
            temperatureReading.SetText((float)Math.Round(temperaturePlayer.currentTemperature) + "\u00B0C");

            //Check for hovering to display text additional info
            if (draggableElement.ContainsPoint(Main.MouseScreen) && !draggableElement.dragging) {
                Main.instance.MouseText("Feels Like: " + Math.Round(temperaturePlayer.modifiedDesiredTemperature) + "\u00B0C (" + TempUtilities.CelsiusToFahrenheit(temperaturePlayer.modifiedDesiredTemperature, true) + "\u00B0F)"
                    + "\nRelative Humidity: " + Math.Round(temperaturePlayer.relativeHumidity * 100f) + "% "
                    + "\nTemperature Change Resistance: " + Math.Round(temperaturePlayer.temperatureChangeResist * 100f) + "%"
                    + "\nComfortable Range: " + Math.Round(temperaturePlayer.comfortableLow) + "\u00B0C - " + Math.Round(temperaturePlayer.comfortableHigh) + "\u00B0C"
                    + "\nHold LeftControl to drag this UI");
            }

            float totalDifference = Math.Abs(temperaturePlayer.comfortableLow - temperaturePlayer.criticalRangeMaximum) + (temperaturePlayer.comfortableHigh + temperaturePlayer.criticalRangeMaximum);

            //Update color of Liquid based off of current temperature
            thermometerLiquid.textureColor = new Color(
                Math.Abs(temperaturePlayer.comfortableLow - temperaturePlayer.criticalRangeMaximum + temperaturePlayer.currentTemperature) / totalDifference, //R
                0f, //G
                (temperaturePlayer.comfortableHigh + temperaturePlayer.criticalRangeMaximum - temperaturePlayer.currentTemperature) / totalDifference, //B
                1f  //A
                );
        }
    }
}