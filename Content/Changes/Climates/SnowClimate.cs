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

        //Since you get the Chilled Debuff in expert mode, we don't want double stacking of cold temperatures.
        //Thus, water temperature will only decrease temperature in normal mode.
        public override float WaterTemperature => Main.expertMode ? 0f : -5f;

        public override bool PlayerZoneBool(Player player) => player.ZoneSnow;
    }
}