using Terraria;

namespace TerraTemp.Content.Changes.EvilTempBiomes {

    public class HallowClimate : EvilClimate {
        public override float TemperatureResistanceModification => 0.1f;

        public override bool EvilZoneBool(Player player) => player.ZoneHoly;
    }
}