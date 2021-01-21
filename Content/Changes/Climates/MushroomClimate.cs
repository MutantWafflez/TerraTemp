using Terraria;

namespace TerraTemp.Content.Changes.Climates {

    public class MushroomClimate : Climate {
        public override float WaterTemperature => -3f;

        public override float GetDesiredTemperatureChange(Player player) => 7.5f;

        public override float GetHumidityChange(Player player) => 0.8f;

        public override bool PlayerZoneBool(Player player) => player.ZoneGlowshroom;
    }
}