using Terraria.ID;

namespace TerraTemp.Content.Changes.BuffChanges.Debuffs {

    public class OnFireDebuff : BuffChange {
        public override int AppliedBuffID => BuffID.OnFire;

        public override float DesiredTemperatureChange => 10f;

        public override float TemperatureResistanceChange => -0.2f;

        public override string AdditionalBuffTip => null;
    }
}