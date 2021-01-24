using Terraria;
using TerraTemp.Custom.Attributes;
using TerraTemp.Custom.Classes.ReflectionMod;

namespace TerraTemp.Content.ModChanges.ModClimates.Calamity {

    [PertainedMod(typeof(CalamityMod))]
    public class SulphurSeaClimate : ModClimate {

        public SulphurSeaClimate(ReflectionMod reflectionMod) : base(reflectionMod) { }

        //Very dry due to the acidic waters. A normal beach, otherwise.
        public override float GetHumidityChange(Player player) => -0.34f;

        public override bool IsPlayerInBiome(Player player) => (reflectionModInstance as CalamityMod).IsPlayerInBiome(player, "sulphursea");
    }
}