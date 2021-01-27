using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.BuffChanges.Debuffs {

    public class OnFireDebuff : BuffChange {
        public override int AppliedBuffID => BuffID.OnFire;

        public override float GetDesiredTemperatureChange(Player player) => 10f;

        public override float GetTemperatureResistanceChange(Player player) => -0.2f;
    }
}