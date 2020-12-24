using Terraria;

namespace TerraTemp.Utilities.EvilTempBiomes {
    public class Hallow : EvilTempBiome {
        public override bool EvilZoneBool => Main.LocalPlayer.ZoneHoly;

        public override float TemperatureResistanceModification => 0.1f;
    }
}
