using Terraria;

namespace TerraTemp.Content.Changes.EvilTempBiomes {

    public class CrimsonClimate : EvilClimate {
        public override float WaterTemperature => -2f;

        public override float GetDesiredTemperatureChange(Player player) => 7.5f;

        public override float GetHumidityChange(Player player) => 0.25f;

        public override float GetTemperatureResistanceChange(Player player) => -0.1f;

        public override bool EvilZoneBool(Player player) => player.ZoneCrimson;
    }
}