using Terraria;

namespace TerraTemp.Content.Changes.EvilTempBiomes {

    public class CorruptionClimate : EvilClimate {
        public override float TemperatureModification => -7.5f;

        public override float TemperatureResistanceModification => -0.1f;

        public override float WaterTemperature => -5f;

        public override bool EvilZoneBool(Player player) => player.ZoneCorrupt;
    }
}