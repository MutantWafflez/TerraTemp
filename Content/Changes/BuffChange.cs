using System;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes {

    public abstract class BuffChange {

        /// <summary>
        /// ID of the buff being changed.
        /// </summary>
        public virtual int AppliedBuffID => -1;

        /// <summary>
        /// By how much this given buff will change the player's Desired (Environmental) Temperature.
        /// </summary>
        public virtual float DesiredTemperatureChange => 0f;

        /// <summary>
        /// By how much this given buff will change the player's Heat Comfortability Range.
        /// </summary>
        public virtual float HeatComfortabilityChange => 0f;

        /// <summary>
        /// By how much this given buff will change the player's Cold Comfortability Range.
        /// </summary>
        public virtual float ColdComfortabilityChange => 0f;

        /// <summary>
        /// By how much this given buff will change the player's Temperature Resistance.
        /// </summary>
        public virtual float TemperatureResistanceChange => 0f;

        /// <summary>
        /// By how much this given buff will change the player's critical temperature range.
        /// </summary>
        public virtual float CriticalTemperatureChange => 0f;

        /// <summary>
        /// Additional tooltip line(s) to be added to the end of the buff's tip. Done automatically
        /// based on how each property is changed, if you wish to add an additional line on top of
        /// this, use base.AdditionalBuffTip + "your string here"
        /// </summary>
        public virtual string AdditionalBuffTip {
            get {
                float heatChange = Math.Abs(HeatComfortabilityChange);
                float coldChange = Math.Abs(ColdComfortabilityChange);
                float tempResistChange = Math.Abs(TemperatureResistanceChange);
                float criticalChange = Math.Abs(CriticalTemperatureChange);

                string fullLine = "";

                //Global Change Check
                if (HeatComfortabilityChange * -1 == ColdComfortabilityChange && heatChange != 0f) {
                    if (HeatComfortabilityChange > 0f) {
                        fullLine += TempUtilities.GetTerraTempTextValue("GlobalTooltip.IncreasedGlobalComfortability", heatChange, true);
                    }
                    else if (HeatComfortabilityChange < 0f) {
                        fullLine += TempUtilities.GetTerraTempTextValue("GlobalTooltip.DecreasedGlobalComfortability", heatChange, true);
                    }
                }
                //Heat/Cold Change Check
                else {
                    if (HeatComfortabilityChange > 0f) {
                        fullLine += TempUtilities.GetTerraTempTextValue("GlobalTooltip.IncreasedHeatComfortability", heatChange, true);
                    }
                    else if (HeatComfortabilityChange < 0f) {
                        fullLine += TempUtilities.GetTerraTempTextValue("GlobalTooltip.DecreasedHeatComfortability", heatChange, true);
                    }

                    if (ColdComfortabilityChange < 0f) {
                        fullLine += TempUtilities.GetTerraTempTextValue("GlobalTooltip.IncreasedColdComfortability", coldChange, true);
                    }
                    else if (ColdComfortabilityChange > 0f) {
                        fullLine += TempUtilities.GetTerraTempTextValue("GlobalTooltip.DecreasedColdComfortability", coldChange, true);
                    }
                }

                //Temperature Resistance Change Check
                if (TemperatureResistanceChange > 0f) {
                    fullLine += TempUtilities.GetTerraTempTextValue("GlobalTooltip.IncreasedTempResistance", tempResistChange, true);
                }
                else if (TemperatureResistanceChange < 0f) {
                    fullLine += TempUtilities.GetTerraTempTextValue("GlobalTooltip.DecreasedTempResistance", tempResistChange, true);
                }

                //Critical Temperature Change Check
                if (CriticalTemperatureChange > 0f) {
                    fullLine += TempUtilities.GetTerraTempTextValue("GlobalTooltip.IncreasedCriticalRange", criticalChange, true);
                }
                else if (CriticalTemperatureChange < 0f) {
                    fullLine += TempUtilities.GetTerraTempTextValue("GlobalTooltip.DecreasedCriticalRange", criticalChange, true);
                }

                return fullLine == "" ? null : fullLine;
            }
        }
    }
}