using Terraria;
using TerraTemp.Custom.Classes.ReflectionMod;

namespace TerraTemp.Content.ModChanges {

    /// <summary>
    /// Abstract class that can be overidden to add mod biome compatibility from other compatible mods.
    /// </summary>
    public class ModClimate : ModChange {

        public ModClimate(ReflectionMod reflectionMod) : base(reflectionMod) { }

        /// <summary>
        /// Returns whether or not the given player is in this specific modded biome. Returns false
        /// by default.
        /// </summary>
        /// <param name="player"> The player to check the modded biome status of. </param>
        public virtual bool IsPlayerInBiome(Player player) => false;
    }
}