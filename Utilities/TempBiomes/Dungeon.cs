using Terraria;

namespace TerraTemp.Utilities.TempBiomes {
    public class Dungeon : TempBiome {

        public override bool PlayerZoneBool => Main.LocalPlayer.ZoneDungeon;

        public override float TemperatureModification => -15f;
    }
}
