using Terraria;

namespace TerraTemp.Content.Changes.TempBiomes {

    public class SpaceClimate : Climate {
        public override float WaterTemperature => -5f;

        public override float GetDesiredTemperatureChange(Player player) => -20f;

        public override bool PlayerZoneBool(Player player) => player.ZoneSkyHeight;
    }
}