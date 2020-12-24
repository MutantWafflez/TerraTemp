using Terraria;

namespace TerraTemp.Utilities.EvilTempBiomes {
    public class Hallow : EvilTempBiome {
        public override float TemperatureResistanceModification => 0.1f;

        public virtual bool EvilZoneBool(Player player) => player.ZoneHoly;
    }
}
