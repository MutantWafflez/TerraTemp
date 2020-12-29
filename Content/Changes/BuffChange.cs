using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes {

    public abstract class BuffChange {

        /// <summary>
        /// ID of the buff being changed.
        /// </summary>
        public virtual int AppliedBuffID => -1;

        /// <summary>
        /// By how much this given buff will change the player's Base Desired (Environmental) Temperature.
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
        public virtual string AdditionalBuffTip => TempUtilities.CreateNewLineBasedOnStats(HeatComfortabilityChange, ColdComfortabilityChange, TemperatureResistanceChange, CriticalTemperatureChange);
    }
}