using Terraria;

namespace TerraTemp.Utilities.TempBiomes {
    public class Snow : TempBiome {
        public override float TemperatureModification {
            get
            {
                //If raining, make it colder
                if (Main.raining) {
                    return -15f;
                }
                return -10f;
            }
        }

        public override bool PlayerZoneBool(Player player) => player.ZoneSnow;
    }
}
