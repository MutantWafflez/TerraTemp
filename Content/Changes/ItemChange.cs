using System.Collections.Generic;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes {

    public abstract class ItemChange {

        /// <summary>
        /// List of Item IDs that this change pertains to. The reason this is a list is for if the
        /// base item is a material (such as the Lava charm), and its effects are carried over into
        /// the new accessory (Lava Waders, with the example of the Lava Charm)
        /// </summary>
        public virtual List<int> AppliedItemIDs => new List<int>();

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
        /// Additional tooltip line(s) to be added to the end of the item's tooltip. Done
        /// automatically based on how each property is changed, if you wish to add an additional
        /// line on top of this, use base.AdditionalTooltip + "your string here"
        /// </summary>
        public virtual string AdditionalTooltip => TempUtilities.CreateNewLineBasedOnStats(HeatComfortabilityChange, ColdComfortabilityChange, TemperatureResistanceChange, CriticalTemperatureChange, DesiredTemperatureChange);
    }
}