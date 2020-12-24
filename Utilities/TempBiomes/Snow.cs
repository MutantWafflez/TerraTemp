using Terraria;

namespace TerraTemp.Utilities.TempBiomes {
    public class Snow : TempBiome {

        public override bool PlayerZoneBool => Main.LocalPlayer.ZoneSnow;

        public override float TemperatureModification {
            get
            {
                //If raining and the player is NOT on the surface/behind a wall, decrease temperature further
                if (Main.raining && Main.LocalPlayer.ZoneOverworldHeight && Main.LocalPlayer.behindBackWall) {
                    return -15f;
                }
                return -10f;
            }
        }
    }
}
