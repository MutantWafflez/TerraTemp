using Terraria;

namespace TerraTemp.Utilities.TempBiomes {
    public class Underworld : TempBiome {
        public override float TemperatureModification => 25f;

        public override bool PlayerZoneBool(Player player) => player.ZoneUnderworldHeight;
    }
}
