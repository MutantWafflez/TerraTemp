using Terraria;

namespace TerraTemp.Content.Prefixes.ColdComfortability {

    public class WarmedPrefix : TemperatureAccessoryPrefix {

        public override void SetDefaults() {
            DisplayName.SetDefault("Warmed");
        }

        public override void ModifyValue(ref float valueMult) {
            valueMult += 0.125f;
        }

        public override float GetColdComfortabilityChange(Player player) => -1f;
    }
}