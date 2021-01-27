using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.BuffChanges.Debuffs {

    public class CursedFlameDebuff : BuffChange {
        public override int AppliedBuffID => BuffID.CursedInferno;

        public override float GetDesiredTemperatureChange(Player player) => 8f;

        public override float GetTemperatureResistanceChange(Player player) => -0.2f;
    }
}