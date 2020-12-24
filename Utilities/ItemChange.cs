using System.Collections.Generic;

namespace TerraTemp.Utilities {

    public abstract class ItemChange {

        /// <summary>
        /// The ID of the item to be modified.
        /// </summary>
        public virtual int AppliedItemID => -1;

        /// <summary>
        /// List that returns what item's IDs have the given item as a material in any part of the
        /// crafting tree or is an alternative to the item. For example, for the Lava Charm, this
        /// would include the Lava Waders, since the Lava Charm is a material in the crafting tree.
        /// </summary>
        public virtual List<int> AlternativeIDs => new List<int>();

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
        /// Additional tooltip line(s) to be added to the end of the item's tooltip.
        /// </summary>
        public virtual string AdditionalTooltip => null;
    }
}