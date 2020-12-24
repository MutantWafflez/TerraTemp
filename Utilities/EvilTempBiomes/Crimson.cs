using Terraria;

namespace TerraTemp.Utilities.EvilTempBiomes {
    public class Crimson : EvilTempBiome {
        public override float TemperatureModification => 7.5f;

        public override float TemperatureResistanceModification => -0.1f;

        public virtual bool EvilZoneBool(Player player) => player.ZoneCrimson;
    }
}
