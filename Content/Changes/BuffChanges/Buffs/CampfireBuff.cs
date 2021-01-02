using Terraria.ID;

namespace TerraTemp.Content.Changes.BuffChanges.Buffs {

    public class CampfireBuff : BuffChange {
        public override int AppliedBuffID => BuffID.Campfire;

        public override float DesiredTemperatureChange => 2f;
    }
}