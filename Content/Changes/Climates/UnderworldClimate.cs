using Terraria;

namespace TerraTemp.Content.Changes.Climates {

    public class UnderworldClimate : Climate {

        //There shouldn't be any water in the underworld anyways; it should be "evaporating"
        public override float WaterTemperature => 0f;

        public override float GetDesiredTemperatureChange(Player player) => 25f;

        // It is absolutely, completely, 100% DRY in the Underworld.
        public override float GetHumidityChange(Player player) => -10f;

        public override bool PlayerZoneBool(Player player) => player.ZoneUnderworldHeight;
    }
}