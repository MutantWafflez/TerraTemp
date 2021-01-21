using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.BuffChanges.Buffs {

    public class DryadBuff : BuffChange {
        public override int AppliedBuffID => BuffID.DryadsWard;

        public override float GetColdComfortabilityChange(Player player) => -2f;

        public override float GetHeatComfortabilityChange(Player player) => 2f;
    }
}