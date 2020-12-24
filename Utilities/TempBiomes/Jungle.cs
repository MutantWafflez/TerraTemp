using Terraria;

namespace TerraTemp.Utilities.TempBiomes {
    public class Jungle : TempBiome {
        public override float TemperatureModification => 12.5f;

        public override bool PlayerZoneBool(Player player) => player.ZoneJungle;
    }
}
