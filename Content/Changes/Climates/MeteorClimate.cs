using Terraria;

namespace TerraTemp.Content.Changes.Climates {

    public class MeteorClimate : Climate {

        public override float GetDesiredTemperatureChange(Player player) => 17.5f;

        public override bool PlayerZoneBool(Player player) => player.ZoneMeteor;
    }
}