using Terraria;
using TerraTemp.Custom.Attributes;
using TerraTemp.Custom.Classes.ReflectionMod;

namespace TerraTemp.Content.ModChanges.ModClimates.Calamity {

    [PertainedMod(typeof(CalamityMod))]
    public class BrimstoneCragsClimate : ModClimate {

        public BrimstoneCragsClimate(ReflectionMod reflectionMod) : base(reflectionMod) { }

        public override float GetTemperatureResistanceChange(Player player) => -0.34f;

        public override bool IsPlayerInBiome(Player player) => (reflectionModInstance as CalamityMod).IsPlayerInBiome(player, "crags");
    }
}