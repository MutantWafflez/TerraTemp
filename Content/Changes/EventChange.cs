using Terraria;

namespace TerraTemp.Content.Changes {

    /// <summary>
    /// Abstract class that can inherited and its fields overriden to change temperature related
    /// values during a given game event.
    /// </summary>
    public abstract class EventChange {

        /// <summary>
        /// The boolean in Main that handles whether this even is taking place. For example, for
        /// rain, Main.raining is the proper bool.
        /// </summary>
        public virtual bool EventBoolean => false;

        /// <summary>
        /// By how much this given event will change the player's Base Desired (Environmental) Temperature.
        /// </summary>
        public virtual float DesiredTemperatureChange => 0f;

        /// <summary>
        /// By how much this given event will change the environment's relative humidity.
        /// </summary>
        public virtual float HumidityChange => 0f;

        /// <summary>
        /// By how much this given event will change the player's Heat Comfortability Range.
        /// </summary>
        public virtual float HeatComfortabilityChange => 0f;

        /// <summary>
        /// By how much this given event will change the player's Cold Comfortability Range.
        /// </summary>
        public virtual float ColdComfortabilityChange => 0f;

        /// <summary>
        /// By how much this given event will change the player's Temperature Resistance.
        /// </summary>
        public virtual float TemperatureResistanceChange => 0f;

        /// <summary>
        /// By how much this given event will change the player's critical temperature range.
        /// </summary>
        public virtual float CriticalTemperatureChange => 0f;

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