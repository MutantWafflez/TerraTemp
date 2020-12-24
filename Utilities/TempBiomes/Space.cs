using Terraria;

namespace TerraTemp.Utilities.TempBiomes {
    public class Space : TempBiome {

        public override bool PlayerZoneBool => Main.LocalPlayer.ZoneSkyHeight;

        public override float TemperatureModification => -20f;
    }
}
