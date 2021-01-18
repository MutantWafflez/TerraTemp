using Terraria.ID;

namespace TerraTemp.Content.Changes.BuffChanges.Debuffs {

    public class IchorDebuff : BuffChange {
        public override int AppliedBuffID => BuffID.Ichor;

        public override float TemperatureResistanceChange => -0.67f;

        public override float ClimateExtremityChange => 0.25f;
    }
}