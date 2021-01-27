using System.Collections.Generic;
using Terraria;
using TerraTemp.Custom;
using TerraTemp.Custom.Interfaces;

namespace TerraTemp.Content.Changes {

    public abstract class ItemHoldoutChange : ITempStatChange {

        /// <summary>
        /// List of Item IDs that this holdout change pertains to.
        /// </summary>
        public virtual HashSet<int> AppliedItemIDs => new HashSet<int>();

        /// <summary>
        /// Additional tooltip line(s) to be added to the end of the item's tooltip. Done
        /// automatically based on how each property is changed.
        /// </summary>
        public virtual string AdditionalTooltip {
            get {
                string additionalLine = TempUtilities.GetTerraTempTextValue("GlobalItemHoldoutChange." + GetType().Name);
                if (additionalLine == "Mods.TerraTemp.GlobalItemHoldoutChange." + GetType().Name) {
                    additionalLine = null;
                }
                return TempUtilities.GetTerraTempTextValue("GlobalTooltip.WhileHeld") + "\n" + TempUtilities.CreateNewLineBasedOnStats(this, additionalLine);
            }
        }

        /// <summary>
        /// By how much holding this given item will change the player's Base Desired
        /// (Environmental) Temperature.
        /// </summary>
        public virtual float GetDesiredTemperatureChange(Player player) => 0f;

        /// <summary>
        /// By how much holding this given item will change the player's Relative Humidity.
        /// </summary>
        public virtual float GetHumidityChange(Player player) => 0f;

        /// <summary>
        /// By how much holding this given item will change the player's Heat Comfortability Range.
        /// </summary>
        public virtual float GetHeatComfortabilityChange(Player player) => 0f;

        /// <summary>
        /// By how much holding this given item will change the player's Cold Comfortability Range.
        /// </summary>
        public virtual float GetColdComfortabilityChange(Player player) => 0f;

        /// <summary>
        /// By how much holding this given item will change the player's Temperature Resistance.
        /// </summary>
        public virtual float GetTemperatureResistanceChange(Player player) => 0f;

        /// <summary>
        /// By how much holding this given item will change the player's critical temperature range.
        /// </summary>
        public virtual float GetCriticalTemperatureChange(Player player) => 0f;

        /// <summary>
        /// By how much holding this given item will change the player's climate extremity value.
        /// </summary>
        public virtual float GetClimateExtremityChange(Player player) => 0f;

        /// <summary>
        /// By how much holding this given item will change the player's sun extremity value (sun
        /// protection, essentially).
        /// </summary>
        public virtual float GetSunExtremityChange(Player player) => 0f;

        /// <summary>
        /// If holding the item has an additional effect on the player, overriding this method can
        /// assist with whatever change. This hook is called in the
        /// MidEnvironmentUpdateItemHoldoutChanges() Method in TempPlayer.
        /// </summary>
        /// <param name="player"> Player that has this item equipped. </param>
        public virtual void AdditionalItemHoldoutEffect(Player player) { }
    }
}