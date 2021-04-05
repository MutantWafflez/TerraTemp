using Terraria;

namespace TerraTemp.Content.Changes.EvilClimates {

    public class CorruptionClimate : EvilClimate {
        public override float WaterTemperature => -5f;

        public override float GetDesiredTemperatureChange(Player player) => -7.5f;

        public override float GetTemperatureResistanceChange(Player player) => -0.1f;

        public override bool EvilZoneBool(Player player) => player.ZoneCorrupt;
    }
}