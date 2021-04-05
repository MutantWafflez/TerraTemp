using Terraria;

namespace TerraTemp.Content.Changes.Climates {

    public class DungeonClimate : Climate {
        public override float WaterTemperature => -5f;

        public override float GetDesiredTemperatureChange(Player player) => -15f;

        public override bool PlayerZoneBool(Player player) => player.ZoneDungeon;
    }
}