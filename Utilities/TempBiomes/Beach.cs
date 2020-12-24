using Terraria;

namespace TerraTemp.Utilities.TempBiomes {
    public class Beach : TempBiome {

        public override bool PlayerZoneBool => Main.LocalPlayer.ZoneBeach;

        public override float TemperatureModification => -2.5f;
    }
}
