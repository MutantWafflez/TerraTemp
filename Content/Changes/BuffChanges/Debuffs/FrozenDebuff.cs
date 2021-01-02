using Terraria.ID;

namespace TerraTemp.Content.Changes.BuffChanges.Debuffs {

    public class FrozenDebuff : BuffChange {
        public override int AppliedBuffID => BuffID.Frozen;

        public override float ColdComfortabilityChange => -10f;

        public override float TemperatureResistanceChange => -0.33f;
    }
}