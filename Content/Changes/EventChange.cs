using Terraria;
using TerraTemp.Custom.Interfaces;

namespace TerraTemp.Content.Changes {

    /// <summary>
    /// Abstract class that can inherited and its fields overriden to change temperature related
    /// values during a given game event.
    /// </summary>
    public abstract class EventChange : ITempStatChange {

        /// <summary>
        /// The boolean in Main that handles whether this even is taking place. For example, for
        /// rain, Main.raining is the proper bool.
        /// </summary>
        public virtual bool EventBoolean => false;

        /// <summary>
        /// By how much this given event will change the player's Base Desired (Environmental) Temperature.
        /// </summary>
        public virtual float GetDesiredTemperatureChange(Player player) => 0f;

        /// <summary>
        /// By how much this given event will change the player's Relative Humidity.
        /// </summary>
        public virtual float GetHumidityChange(Player player) => 0f;

        /// <summary>
        /// By how much this given event will change the player's Heat Comfortability Range.
        /// </summary>
        public virtual float GetHeatComfortabilityChange(Player player) => 0f;

        /// <summary>
        /// By how much this given event will change the player's Cold Comfortability Range.
        /// </summary>
        public virtual float GetColdComfortabilityChange(Player player) => 0f;

        /// <summary>
        /// By how much this given event will change the player's Temperature Resistance.
        /// </summary>
        public virtual float GetTemperatureResistanceChange(Player player) => 0f;

        /// <summary>
        /// By how much this given event will change the player's critical temperature range.
        /// </summary>
        public virtual float GetCriticalTemperatureChange(Player player) => 0f;

        /// <summary>
        /// By how much this given event will change the player's climate extremity value.
        /// </summary>
        public virtual float GetClimateExtremityChange(Player player) => 0f;

        /// <summary>
        /// By how much this given event will change the player's sun extremity value (sun
        /// protection, essentially).
        /// </summary>
        public virtual float GetSunExtremityChange(Player player) => 0f;

        /// <summary>
        /// Whether or not, based on player position/bools/etc, the event's effects should be
        /// applied to the given player. For example, if the player isn't on the surface and it's
        /// raining, the humidity should not be changed. Returning true will apply the effects,
        /// false does the opposite. Returns true by default.
        /// </summary>
        /// <param name="player"> Player instance to be checked. </param>
        /// <returns> Returns whether or not to apply the event effects. </returns>
        public virtual bool ApplyEventEffects(Player player) => true;
    }
}