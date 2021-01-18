using Terraria.ID;

namespace TerraTemp.Content.Changes.BuffChanges.Buffs {

    public class DryadBuff : BuffChange {
        public override int AppliedBuffID => BuffID.DryadsWard;

        public override float ColdComfortabilityChange => -2f;

        public override float HeatComfortabilityChange => 2f;
    }
}