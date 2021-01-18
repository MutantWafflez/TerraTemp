using Terraria;

namespace TerraTemp.Content.Changes.TempBiomes {

    public class DesertClimate : Climate {
        public override float TemperatureModification => 10f;

        public override float HumidityModification => -0.34f;

        public override float WaterTemperature => -3f;

        public override bool PlayerZoneBool(Player player) => player.ZoneDesert;
    }
}