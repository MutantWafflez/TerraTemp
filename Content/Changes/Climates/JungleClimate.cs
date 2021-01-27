using Terraria;

namespace TerraTemp.Content.Changes.TempBiomes {

    public class JungleClimate : Climate {
        public override float WaterTemperature => -3f;

        public override float GetDesiredTemperatureChange(Player player) => 10.5f;

        public override float GetHumidityChange(Player player) => 0.34f;

        public override bool PlayerZoneBool(Player player) => player.ZoneJungle;
    }
}