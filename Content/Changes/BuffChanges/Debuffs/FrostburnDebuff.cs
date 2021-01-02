using Terraria.ID;

namespace TerraTemp.Content.Changes.BuffChanges.Debuffs {

    public class FrostburnDebuff : BuffChange {
        public override int AppliedBuffID => BuffID.Frostburn;

        public override float DesiredTemperatureChange => -8f;

        public override float TemperatureResistanceChange => -0.2f;
    }
}