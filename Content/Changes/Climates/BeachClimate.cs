using Terraria;

namespace TerraTemp.Content.Changes.TempBiomes {

    public class BeachClimate : Climate {
        public override float TemperatureModification => -2.5f;

        public override bool PlayerZoneBool(Player player) => player.ZoneBeach;
    }
}