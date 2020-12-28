using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Items {

    public class Thermometer : ModItem {

        public override void SetStaticDefaults() {
            Tooltip.SetDefault("Displays several temperature related statistics");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.DepthMeter);
            item.width = 32;
            item.height = 32;
            item.accessory = false;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips) {
            TempPlayer tempPlayer = Main.player[item.owner].GetModPlayer<TempPlayer>();
            float desiredTemp = tempPlayer.desiredTemperature;
            float desiredWetTemp = tempPlayer.desiredWetTemperature;
            float currentTemp = tempPlayer.currentTemperature;
            float playerLow = tempPlayer.comfortableLow;
            float playerHigh = tempPlayer.comfortableHigh;
            float playerCriticalZone = tempPlayer.criticalRangeMaximum;
            float resistChange = tempPlayer.temperatureChangeResist;
            float relativeHumidity = tempPlayer.relativeHumidity;

            TooltipLine currentLine = new TooltipLine(mod,
            "CurrentTemp",
            "Current Body Temperature: " + Math.Round(currentTemp) + "C (" + TempUtilities.CelsiusToFahrenheit(currentTemp, true) + "F)");
            if ((currentTemp >= playerHigh && currentTemp <= playerHigh + (playerCriticalZone / 2f)) || (currentTemp <= playerLow && currentTemp >= playerLow - (playerCriticalZone / 2f))) {
                currentLine.overrideColor = new Color(255, 155, 0);
            }
            else if (currentTemp >= playerHigh + (playerCriticalZone / 2f) || currentTemp <= playerLow - (playerCriticalZone / 2f)) {
                currentLine.overrideColor = new Color(255, 0, 0);
            }
            tooltips.Add(currentLine);

            TooltipLine desiredLine = new TooltipLine(mod,
            "DesiredTemp",
            "Environment Temperature: " + Math.Round(desiredTemp) + "C (" + TempUtilities.CelsiusToFahrenheit(desiredTemp, true) + "F)");
            tooltips.Add(desiredLine);

            TooltipLine desiredWetLine = new TooltipLine(mod,
            "DesiredWetTemp",
            "Feels Like: " + Math.Round(desiredWetTemp) + "C (" + TempUtilities.CelsiusToFahrenheit(desiredWetTemp, true) + "F)");
            tooltips.Add(desiredWetLine);

            TooltipLine humidityLine = new TooltipLine(mod,
            "RelativeHumidity",
            "Relative Humidity: " + Math.Round(relativeHumidity * 100f) + "%");
            tooltips.Add(humidityLine);

            TooltipLine resistLine = new TooltipLine(mod,
            "ResistChange",
            "Temperature Change Resistance: " + Math.Round(resistChange * 100f) + "%");
            tooltips.Add(resistLine);

            TooltipLine comfortableLine = new TooltipLine(mod,
            "PlayerComfortability",
            "Comfortable Range: " + Math.Round(playerLow) + "C - " + Math.Round(playerHigh) + "C");
            tooltips.Add(comfortableLine);
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Glass, 3);
            recipe.AddIngredient(ItemID.WaterBucket, 1);
            recipe.AddRecipeGroup("IronBar", 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}