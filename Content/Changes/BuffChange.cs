using System;
using Terraria;
using Terraria.ModLoader;
using TerraTemp.Common.Systems;
using TerraTemp.Custom.Interfaces;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Content.Changes {

    /// <summary>
    /// Abstract class that can be inherited and its fields overriden to give temperature related
    /// changes to any pre-existing buffs.
    /// </summary>
    public abstract class BuffChange : ITempStatChange, ILoadable {

        /// <summary>
        /// ID of the buff being changed.
        /// </summary>
        public virtual int AppliedBuffID => -1;

        /// <summary>
        /// Additional tooltip line(s) to be added to the end of the buff's tip. Done automatically
        /// based on how each property is changed, if you wish to add an additional line on top of
        /// this, use base.AdditionalBuffTip + "your string here"
        /// </summary>
        public virtual string AdditionalBuffTip => LocalizationUtilities.CreateNewLineBasedOnStats(this);

        /// <summary>
        /// By how much this given buff will change the player's Base Desired (Environmental) Temperature.
        /// </summary>
        public virtual float GetDesiredTemperatureChange(Player player) => 0f;

        /// <summary>
        /// By how much this given buff will change the player's Relative Humidity.
        /// </summary>
        public virtual float GetHumidityChange(Player player) => 0f;

        /// <summary>
        /// By how much this given buff will change the player's Heat Comfortability Range.
        /// </summary>
        public virtual float GetHeatComfortabilityChange(Player player) => 0f;

        /// <summary>
        /// By how much this given buff will change the player's Cold Comfortability Range.
        /// </summary>
        public virtual float GetColdComfortabilityChange(Player player) => 0f;

        /// <summary>
        /// By how much this given buff will change the player's Temperature Resistance.
        /// </summary>
        public virtual float GetTemperatureResistanceChange(Player player) => 0f;

        /// <summary>
        /// By how much this given buff will change the player's critical temperature range.
        /// </summary>
        public virtual float GetCriticalTemperatureChange(Player player) => 0f;

        /// <summary>
        /// By how much this given buff will change the player's climate extremity value.
        /// </summary>
        public virtual float GetClimateExtremityChange(Player player) => 0f;

        /// <summary>
        /// By how much this given buff will change the player's sun extremity value (sun
        /// protection, essentially).
        /// </summary>
        public virtual float GetSunExtremityChange(Player player) => 0f;

        public void Load(Mod mod) {
            ContentListSystem.buffChanges.Add((BuffChange)Activator.CreateInstance(GetType()));
        }

        public void Unload() { }
    }
}