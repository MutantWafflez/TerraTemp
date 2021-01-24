using Terraria;
using TerraTemp.Custom.Attributes;
using TerraTemp.Custom.Classes.ReflectionMod;

namespace TerraTemp.Content.ModChanges.ModClimates.Calamity {

    [PertainedMod(typeof(CalamityMod))]
    public class AstralInfectionClimate : ModClimate {

        public AstralInfectionClimate(ReflectionMod reflectionMod) : base(reflectionMod) { }

        //Hot during the day, cold during the night. Cause wacky star stuff, or something.
        public override float GetDesiredTemperatureChange(Player player) => Main.dayTime ? 10f : -10f;

        public override bool IsPlayerInBiome(Player player) => (reflectionModInstance as CalamityMod).IsPlayerInBiome(player, "astral");
    }
}