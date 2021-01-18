using Terraria;

namespace TerraTemp.Content.Changes.TempBiomes {

    public class DungeonClimate : Climate {
        public override float TemperatureModification => -15f;

        public override float WaterTemperature => -5f;

        public override bool PlayerZoneBool(Player player) => player.ZoneDungeon;
    }
}