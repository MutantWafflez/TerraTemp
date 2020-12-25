using Terraria;

namespace TerraTemp.Content.Changes.TempBiomes {

    public class SnowClimate : Climate {

        public override float TemperatureModification {
            get {
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