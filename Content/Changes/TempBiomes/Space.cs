using Terraria;

namespace TerraTemp.Content.Changes.TempBiomes {

    public class Space : TempBiome {
        public override float TemperatureModification => -20f;

        public override bool PlayerZoneBool(Player player) => player.ZoneSkyHeight;
    }
}