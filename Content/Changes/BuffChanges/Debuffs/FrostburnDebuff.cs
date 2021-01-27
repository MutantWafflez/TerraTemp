using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.BuffChanges.Debuffs {

    public class FrostburnDebuff : BuffChange {
        public override int AppliedBuffID => BuffID.Frostburn;

        public override float GetDesiredTemperatureChange(Player player) => -8f;

        public override float GetTemperatureResistanceChange(Player player) => -0.2f;
    }
}