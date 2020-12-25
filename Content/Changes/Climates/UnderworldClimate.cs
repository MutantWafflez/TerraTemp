using Terraria;

namespace TerraTemp.Content.Changes.TempBiomes {

    public class UnderworldClimate : Climate {
        public override float TemperatureModification => 25f;

        public override bool PlayerZoneBool(Player player) => player.ZoneUnderworldHeight;
    }
}