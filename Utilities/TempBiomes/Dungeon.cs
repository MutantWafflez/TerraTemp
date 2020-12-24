using Terraria;

namespace TerraTemp.Utilities.TempBiomes {

    public class Dungeon : TempBiome {
        public override float TemperatureModification => -15f;

        public override bool PlayerZoneBool(Player player) => player.ZoneDungeon;
    }
}