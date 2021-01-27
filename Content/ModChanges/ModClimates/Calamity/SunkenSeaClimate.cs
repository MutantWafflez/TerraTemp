using Terraria;
using TerraTemp.Custom.Attributes;
using TerraTemp.Custom.Classes.ReflectionMod;

namespace TerraTemp.Content.ModChanges.ModClimates.Calamity {

    [PertainedMod(typeof(CalamityMod))]
    public class SunkenSeaClimate : ModClimate {

        public SunkenSeaClimate(ReflectionMod reflectionMod) : base(reflectionMod) { }

        //Colder due to it being much more underground, away from everything else.
        public override float GetDesiredTemperatureChange(Player player) => -5f;

        public override float GetHumidityChange(Player player) => 0.5f;

        public override bool IsPlayerInBiome(Player player) => (reflectionModInstance as CalamityMod).IsPlayerInBiome(player, "sunkensea");
    }
}