using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.BuffChanges.Debuffs {

    public class IchorDebuff : BuffChange {
        public override int AppliedBuffID => BuffID.Ichor;

        public override float GetTemperatureResistanceChange(Player player) => -0.67f;

        public override float GetClimateExtremityChange(Player player) => 0.25f;
    }
}