using Terraria;

namespace TerraTemp.Utilities.TempBiomes {
    public class Underworld : TempBiome {

        public override bool PlayerZoneBool => Main.LocalPlayer.ZoneUnderworldHeight;

        public override float TemperatureModification => 25f;
    }
}
