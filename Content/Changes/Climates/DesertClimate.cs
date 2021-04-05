using Terraria;

namespace TerraTemp.Content.Changes.Climates {

    public class DesertClimate : Climate {
        public override float WaterTemperature => -3f;

        public override float GetDesiredTemperatureChange(Player player) => 10f;

        public override float GetHumidityChange(Player player) => -0.34f;

        public override bool PlayerZoneBool(Player player) => player.ZoneDesert;
    }
}