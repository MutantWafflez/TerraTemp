using Terraria;
using Terraria.ModLoader;
using TerraTemp.Custom.Attributes;

namespace TerraTemp.Custom.Classes.ReflectionMod {

    [InternalModName("CalamityMod")]
    public class CalamityMod : ReflectionMod {

        public CalamityMod(Mod instance) : base(instance) { }

        /// <summary>
        /// Makes the given player Cold and Heat immune since TerraTemp already has that covered.
        /// </summary>
        /// <param name="player"> The player to remove the temperature system for. </param>
        public void RemoveDeathModeTemperatureSystem(Player player) {
            ModInstance.Call("MakeColdImmune", player);
            ModInstance.Call("MakeHeatImmune", player);
        }
    }
}