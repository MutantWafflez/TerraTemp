using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.BuffChanges.Debuffs {

    public class FrozenDebuff : BuffChange {
        public override int AppliedBuffID => BuffID.Frozen;

        public override float GetColdComfortabilityChange(Player player) => -10f;

        public override float GetTemperatureResistanceChange(Player player) => -0.33f;
    }
}