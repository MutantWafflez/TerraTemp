using Terraria;

namespace TerraTemp.Content.Changes.TempBiomes {

    public class UnderworldClimate : Climate {
        public override float TemperatureModification => 25f;

        // It is absolutely, completely, 100% DRY in the Underworld.
        public override float HumidityModification => -10f;

        public override bool PlayerZoneBool(Player player) => player.ZoneUnderworldHeight;
    }
}