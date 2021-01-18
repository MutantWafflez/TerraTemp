using Terraria.ID;

namespace TerraTemp.Content.Changes.BuffChanges.Buffs {

    public class EnduranceBuff : BuffChange {
        public override int AppliedBuffID => BuffID.Endurance;

        public override float TemperatureResistanceChange => 0.15f;
    }
}