using Terraria;

namespace TerraTemp.Content.Changes.TempBiomes {

    public class Desert : TempBiome {
        public override float TemperatureModification => 10f;

        public override bool PlayerZoneBool(Player player) => player.ZoneDesert;
    }
}