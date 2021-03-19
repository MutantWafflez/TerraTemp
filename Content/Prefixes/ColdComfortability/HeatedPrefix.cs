using Terraria;

namespace TerraTemp.Content.Prefixes.ColdComfortability {

    public class HeatedPrefix : TemperatureAccessoryPrefix {

        public override void SetDefaults() {
            DisplayName.SetDefault("Heated");
        }

        public override float RollChance(Item item) => 0.75f;

        public override void ModifyValue(ref float valueMult) {
            valueMult += 0.25f;
        }

        public override float GetColdComfortabilityChange(Player player) => -2f;
    }
}