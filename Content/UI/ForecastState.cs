using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using TerraTemp.Common.Players;

namespace TerraTemp.Content.UI {

    /// <summary>
    /// UI State that handles the forecast UI for the Meteorologist NPC forecast function
    /// </summary>
    public class ForecastState : UIState {
        public const int BackPanelPadding = 30;
        public const int SpaceBetweenDayPanels = 2;
        public const int DayPanelsPadding = 4;
        public const int TemperatureReadingPadding = 10;
        public const int SeparateReadingsPadding = 20;
        public const int AdditionalTopDayPanelPadding = 20;
        public UIPanel backPanel;
        public UIPanel[] dayPanels;
        public UIText[,] dayPanelTexts;

        public override void OnInitialize() {
            backPanel = new UIPanel();
            backPanel.SetPadding(BackPanelPadding);
            backPanel.Height.Set(0f, 0.34f);
            backPanel.Width.Set(0f, 0.5f);
            backPanel.Left.Set(0f, 0.25f);
            backPanel.Top.Set(0f, 0.34f);
            Append(backPanel);

            dayPanels = new UIPanel[5];
            for (int i = 0; i < dayPanels.Length; i++) {
                UIPanel dayPanel = dayPanels[i] = new UIPanel();
                dayPanel.SetPadding(DayPanelsPadding);
                dayPanel.Width.Set((backPanel.GetDimensions().Width - BackPanelPadding * 2) * 0.2f, 0f);
                dayPanel.Height.Set(backPanel.GetDimensions().Height - BackPanelPadding * 2, 0f);
                dayPanel.Left.Set((dayPanel.Width.Pixels + 2) * i - SpaceBetweenDayPanels * (dayPanels.Length - 3), 0f);
                backPanel.Append(dayPanel);
            }

            dayPanelTexts = new UIText[dayPanels.Length, 7];
            for (int i = 0; i < dayPanels.Length; i++) {
                UIPanel currentPanel = dayPanels[i];

                string dayText = i == 0 ? "Today" : i == 1 ? "Tomorrow" : "Tomorrow + " + (i - 1);

                UIText dayOfWeekText = dayPanelTexts[i, 0] = new UIText(dayText, 1.15f);
                currentPanel.Append(dayOfWeekText);

                UIText highText = dayPanelTexts[i, 1] = new UIText("High:", 1.15f);
                currentPanel.Append(highText);

                UIText temperatureHighReading = dayPanelTexts[i, 2] = new UIText("20\u00B0", large: true);
                currentPanel.Append(temperatureHighReading);

                UIText lowText = dayPanelTexts[i, 3] = new UIText("Low:", 1.15f);
                currentPanel.Append(lowText);

                UIText temperatureLowReading = dayPanelTexts[i, 4] = new UIText("20\u00B0", large: true);
                currentPanel.Append(temperatureLowReading);

                UIText humidityText = dayPanelTexts[i, 5] = new UIText("Humidity Deviation: ", 1.15f);
                currentPanel.Append(humidityText);

                UIText humidityReading = dayPanelTexts[i, 6] = new UIText("0%", large: true);
                currentPanel.Append(humidityReading);
            }
        }

        protected override void DrawChildren(SpriteBatch spriteBatch) {
            base.DrawChildren(spriteBatch);
            //For some reason, Initialization of UIText positions doesn't work properly when using GetDimensions() in the OnInitialize() method (above)
            //Thus, we have to modify our positions as they draw, which can be beneficial since numbers are a bit different in size, so we can keep things centered as an added bonus
            for (int i = 0; i < dayPanels.Length; i++) {
                UIPanel currentPanel = dayPanels[i];

                UIText dayOfWeekText = dayPanelTexts[i, 0];
                dayOfWeekText.Left.Set(currentPanel.Width.Pixels * 0.5f - DayPanelsPadding - dayOfWeekText.GetDimensions().Width / 2f, 0f);
                dayOfWeekText.Top.Set(-(DayPanelsPadding * 2) - dayOfWeekText.GetDimensions().Height, 0f);

                UIText highText = dayPanelTexts[i, 1];
                highText.Left.Set(currentPanel.Width.Pixels * 0.5f - DayPanelsPadding - highText.GetDimensions().Width / 2f, 0f);
                highText.Top.Set(AdditionalTopDayPanelPadding, 0f);

                UIText temperatureHighReading = dayPanelTexts[i, 2];
                //Temperature for the given day at absolute noon
                temperatureHighReading.SetText(Math.Round(TempPlayer.NormalTemperature + ((27000f / 60f / 50f) * TerraTemp.weeklyTemperatureDeviations[i])) + "\u00B0");
                temperatureHighReading.Left.Set(currentPanel.Width.Pixels * 0.5f - DayPanelsPadding - temperatureHighReading.GetDimensions().Width / 2f, 0f);
                temperatureHighReading.Top.Set(highText.GetDimensions().Height + highText.Top.Pixels + TemperatureReadingPadding, 0f);

                UIText lowText = dayPanelTexts[i, 3];
                lowText.Left.Set(currentPanel.Width.Pixels * 0.5f - DayPanelsPadding - lowText.GetDimensions().Width / 2f, 0f);
                lowText.Top.Set(temperatureHighReading.GetDimensions().Height + temperatureHighReading.Top.Pixels + SeparateReadingsPadding, 0f);

                UIText temperatureLowReading = dayPanelTexts[i, 4];
                //Temperature for the given night at absolute midnight
                temperatureLowReading.SetText(Math.Round(TempPlayer.NormalTemperature - (16200f / 60f / 30f * TerraTemp.weeklyTemperatureDeviations[i])) + "\u00B0");
                temperatureLowReading.Left.Set(currentPanel.Width.Pixels * 0.5f - DayPanelsPadding - temperatureLowReading.GetDimensions().Width / 2f, 0f);
                temperatureLowReading.Top.Set(lowText.GetDimensions().Height + lowText.Top.Pixels + TemperatureReadingPadding, 0f);

                UIText humidityText = dayPanelTexts[i, 5];
                humidityText.Left.Set(currentPanel.Width.Pixels * 0.5f - humidityText.GetDimensions().Width / 2f, 0f);
                humidityText.Top.Set(temperatureLowReading.GetDimensions().Height + temperatureLowReading.Top.Pixels + SeparateReadingsPadding, 0f);

                UIText humidityReading = dayPanelTexts[i, 6];
                //The deviation of humidity for the given day regardless of the given climate (biome)
                humidityReading.SetText(Math.Round(TerraTemp.weeklyHumidityDeviations[i] * 100f) + "%");
                humidityReading.Left.Set(currentPanel.Width.Pixels * 0.5f - DayPanelsPadding - humidityReading.GetDimensions().Width / 2f, 0f);
                humidityReading.Top.Set(humidityText.GetDimensions().Height + humidityText.Top.Pixels + TemperatureReadingPadding, 0f);
            }
        }
    }
}