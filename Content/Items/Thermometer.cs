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
            float desiredTemp = Main.player[item.owner].GetModPlayer<TempPlayer>().desiredTemperature;
            float currentTemp = Main.player[item.owner].GetModPlayer<TempPlayer>().currentTemperature;
            float playerLow = Main.player[item.owner].GetModPlayer<TempPlayer>().comfortableLow;
            float playerHigh = Main.player[item.owner].GetModPlayer<TempPlayer>().comfortableHigh;
            float playerCriticalZone = Main.player[item.owner].GetModPlayer<TempPlayer>().criticalRangeMaximum;
            float resistChange = Main.player[item.owner].GetModPlayer<TempPlayer>().temperatureChangeResist;
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
            TooltipLine resistLine = new TooltipLine(mod,
            "ResistChange",
            "Temperature Change Resistance: " + Math.Round(resistChange * 100) + "%");
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
