using Terraria.ID;

namespace TerraTemp.Content.Changes.BuffChanges.Debuffs {

    public class ChilledDebuff : BuffChange {
        public override int AppliedBuffID => BuffID.Chilled;

        public override float DesiredTemperatureChange => -5f;
    }
}