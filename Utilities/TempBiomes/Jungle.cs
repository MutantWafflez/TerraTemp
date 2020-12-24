using Terraria;

namespace TerraTemp.Utilities.TempBiomes {
    public class Jungle : TempBiome {

        public override bool PlayerZoneBool => Main.LocalPlayer.ZoneJungle;

        public override float TemperatureModification => 12.5f;
    }
}
