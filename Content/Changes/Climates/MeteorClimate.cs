using Terraria;

namespace TerraTemp.Content.Changes.Climates {

    public class MeteorClimate : Climate {
        public override float TemperatureModification => 17.5f;

        public override bool PlayerZoneBool(Player player) => player.ZoneMeteor;
    }
}