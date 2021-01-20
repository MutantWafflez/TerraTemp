using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;
using TerraTemp.Custom;

namespace TerraTemp.Content.Base.Items {

    /// <summary>
    /// Abstract class for any item that can affect a given player's temperature stats in ANY given
    /// way. Tooltip is automatically handled, no matter the change.
    /// </summary>
    public abstract class TempItem : ModItem {

        /// <summary>
        /// By how much this given item will change the player's Base Desired (Environmental) Temperature.
        /// </summary>
        public virtual float DesiredTemperatureChange => 0f;

        /// <summary>
        /// By how much this given item will change the player's Heat Comfortability Range.
        /// </summary>
        public virtual float HeatComfortabilityChange => 0f;

        /// <summary>
        /// By how much this given item will change the player's Cold Comfortability Range.
        /// </summary>
        public virtual float ColdComfortabilityChange => 0f;

        /// <summary>
        /// By how much this given item will change the player's Temperature Resistance.
        /// </summary>
        public virtual float TemperatureResistanceChange => 0f;

        /// <summary>
        /// By how much this given item will change the player's critical temperature range.
        /// </summary>
        public virtual float CriticalTemperatureChange => 0f;

        /// <summary>
        /// By how much this given item will change the player's climate extremity value.
        /// </summary>
        public virtual float ClimateExtremityChange => 0f;

        public override void ModifyTooltips(List<TooltipLine> tooltips) {
            string returnedLine = TempUtilities.CreateNewLineBasedOnStats(HeatComfortabilityChange, ColdComfortabilityChange, TemperatureResistanceChange, CriticalTemperatureChange, DesiredTemperatureChange, ClimateExtremityChange);
            if (returnedLine != null) {
                TooltipLine newLine = new TooltipLine(mod, "TempAdditionalLine", returnedLine);

                TooltipLine defenseLine = tooltips.FirstOrDefault(t => t.mod == "Terraria" && t.Name == "Defense");
                TooltipLine buffDurationLine = tooltips.FirstOrDefault(t => t.mod == "Terraria" && t.Name == "BuffTime");
                TooltipLine modifierLine = tooltips.FirstOrDefault(t => t.mod == "Terraria" && t.Name.Contains("Prefix"));
                TooltipLine sellLine = tooltips.FirstOrDefault(tooltip => tooltip.mod == "Terraria" && (tooltip.Name == "Price" || tooltip.Name == "SpecialPrice"));

                if (defenseLine != null) {
                    tooltips.Insert(tooltips.IndexOf(defenseLine) + 1, newLine);
                }
                else if (buffDurationLine != null) {
                    tooltips.Insert(tooltips.IndexOf(buffDurationLine), newLine);
                }
                else if (modifierLine != null) {
                    tooltips.Insert(tooltips.IndexOf(modifierLine), newLine);
                }
                else if (sellLine != null) {
                    tooltips.Insert(tooltips.IndexOf(sellLine), newLine);
                }
                else {
                    tooltips.Add(newLine);
                }
            }
        }
    }
}