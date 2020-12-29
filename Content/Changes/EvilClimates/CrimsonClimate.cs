using Terraria;

namespace TerraTemp.Content.Changes.EvilTempBiomes {

    public class CrimsonClimate : EvilClimate {
        public override float TemperatureModification => 7.5f;

        public override float HumidityModification => 0.25f;

        public override float TemperatureResistanceModification => -0.1f;

        public override bool EvilZoneBool(Player player) => player.ZoneCrimson;
    }
}