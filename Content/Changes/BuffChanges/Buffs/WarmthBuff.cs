using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.BuffChanges.Buffs {

    public class WarmthBuff : BuffChange {
        public override int AppliedBuffID => BuffID.Warmth;

        public override float GetColdComfortabilityChange(Player player) => -8f;
    }
}