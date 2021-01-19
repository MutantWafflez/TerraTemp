using Terraria;

namespace TerraTemp.Content.Changes.Climates {

    public class MushroomClimate : Climate {
        public override float TemperatureModification => 7.5f;

        public override float HumidityModification => 0.8f;

        public override float WaterTemperature => -3f;

        public override bool PlayerZoneBool(Player player) => player.ZoneGlowshroom;
    }
}