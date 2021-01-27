using Terraria;
using TerraTemp.Custom.Classes.ReflectionMod;

namespace TerraTemp.Content.ModChanges {

    /// <summary>
    /// Abstract class that can be overriden and handles ALL compatible modded events.
    /// </summary>
    public abstract class ModEvent : ModChange {

        public ModEvent(ReflectionMod reflectionModInstance) : base(reflectionModInstance) { }

        /// <summary>
        /// Whether or not, based on player position/bools/etc, the event's effects should be
        /// applied to the given player. For example, if the player isn't on the surface and it's
        /// raining, the humidity should not be changed. Returning true will apply the effects,
        /// false does the opposite. Returns false by default.
        /// </summary>
        /// <param name="player"> Player instance to be checked. </param>
        /// <returns> Returns whether or not to apply the event effects. </returns>
        public virtual bool ApplyEventEffects(Player player) => false;
    }
}