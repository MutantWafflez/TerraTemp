using Terraria.ID;

namespace TerraTemp.Content.Changes.BuffChanges.Debuffs {

    public class CursedFlameDebuff : BuffChange {
        public override int AppliedBuffID => BuffID.CursedInferno;

        public override float DesiredTemperatureChange => 8f;

        public override float TemperatureResistanceChange => -0.2f;
    }
}