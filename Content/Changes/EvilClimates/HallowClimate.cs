using Terraria;

namespace TerraTemp.Content.Changes.EvilClimates {

    public class HallowClimate : EvilClimate {
        public override float WaterTemperature => 0f;

        public override float GetTemperatureResistanceChange(Player player) => 0.1f;

        public override bool EvilZoneBool(Player player) => player.ZoneHoly;
    }
}