using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Items.Miscellaneous {

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
            TempPlayer tempPlayer = Main.player[item.owner].GetTempPlayer();
            float baseDesiredTemp = tempPlayer.baseDesiredTemperature;
            float modifiedDesiredTemp = tempPlayer.modifiedDesiredTemperature;
            float currentTemp = tempPlayer.currentTemperature;
            float comfortableLow = tempPlayer.comfortableLow;
            float comfortableHigh = tempPlayer.comfortableHigh;
            float criticalRangeMaximum = tempPlayer.criticalRangeMaximum;
            float tempeResistChange = tempPlayer.temperatureChangeResist;
            float relativeHumidity = tempPlayer.relativeHumidity;

            TooltipLine currentLine = new TooltipLine(mod,
            "CurrentTemp",
            "Current Body Temperature: " + Math.Round(currentTemp) + "C (" + TempUtilities.CelsiusToFahrenheit(currentTemp, true) + "F)");
            if ((currentTemp >= comfortableHigh && currentTemp <= comfortableHigh + (criticalRangeMaximum / 2f)) || (currentTemp <= comfortableLow && currentTemp >= comfortableLow - (criticalRangeMaximum / 2f))) {
                currentLine.overrideColor = new Color(255, 155, 0);
            }
            else if (currentTemp >= comfortableHigh + (criticalRangeMaximum / 2f) || currentTemp <= comfortableLow - (criticalRangeMaximum / 2f)) {
                currentLine.overrideColor = new Color(255, 0, 0);
            }
            tooltips.Add(currentLine);

            TooltipLine baseDesiredLine = new TooltipLine(mod,
            "BaseDesiredTemp",
            "Environment Temperature: " + Math.Round(baseDesiredTemp) + "C (" + TempUtilities.CelsiusToFahrenheit(baseDesiredTemp, true) + "F)");
            tooltips.Add(baseDesiredLine);

            TooltipLine moddedDesiredLine = new TooltipLine(mod,
            "ModifiedDesiredTemp",
            "Feels Like: " + Math.Round(modifiedDesiredTemp) + "C (" + TempUtilities.CelsiusToFahrenheit(modifiedDesiredTemp, true) + "F)");
            tooltips.Add(moddedDesiredLine);

            TooltipLine humidityLine = new TooltipLine(mod,
            "RelativeHumidity",
            "Relative Humidity: " + Math.Round(relativeHumidity * 100f) + "%");
            tooltips.Add(humidityLine);

            TooltipLine resistLine = new TooltipLine(mod,
            "ResistChange",
            "Temperature Change Resistance: " + Math.Round(tempeResistChange * 100f) + "%");
            tooltips.Add(resistLine);

            TooltipLine comfortableLine = new TooltipLine(mod,
            "PlayerComfortability",
            "Comfortable Range: " + Math.Round(comfortableLow) + "C - " + Math.Round(comfortableHigh) + "C");
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