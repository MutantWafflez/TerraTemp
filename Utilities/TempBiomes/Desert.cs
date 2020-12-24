using Terraria;

namespace TerraTemp.Utilities.TempBiomes {
    public class Desert : TempBiome {

        public override bool PlayerZoneBool => Main.LocalPlayer.ZoneDesert;

        public override float TemperatureModification => 10f;
    }
}
