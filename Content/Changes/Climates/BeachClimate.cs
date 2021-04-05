using Terraria;

namespace TerraTemp.Content.Changes.Climates {

    public class BeachClimate : Climate {
        public override float WaterTemperature => -7f;

        public override float GetDesiredTemperatureChange(Player player) => -2.5f;

        public override float GetHumidityChange(Player player) => 0.4f;

        public override bool PlayerZoneBool(Player player) => player.ZoneBeach;
    }
}