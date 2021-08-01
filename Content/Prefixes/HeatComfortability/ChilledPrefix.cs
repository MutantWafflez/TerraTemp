using Terraria;

namespace TerraTemp.Content.Prefixes.HeatComfortability {

    public class ChilledPrefix : TemperatureAccessoryPrefix {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Chilled");
        }

        public override void ModifyValue(ref float valueMult) {
            valueMult += 0.125f;
        }

        public override float GetHeatComfortabilityChange(Player player) => 1f;
    }
}