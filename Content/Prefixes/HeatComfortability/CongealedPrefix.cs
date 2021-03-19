using Terraria;

namespace TerraTemp.Content.Prefixes.HeatComfortability {

    public class CongealedPrefix : TemperatureAccessoryPrefix {

        public override void SetDefaults() {
            DisplayName.SetDefault("Congealed");
        }

        public override float RollChance(Item item) => 0.75f;

        public override void ModifyValue(ref float valueMult) {
            valueMult += 0.25f;
        }

        public override float GetHeatComfortabilityChange(Player player) => 2f;
    }
}