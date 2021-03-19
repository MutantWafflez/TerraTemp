using Terraria;

namespace TerraTemp.Content.Prefixes.SunExtremity {

    public class ShadedPrefix : TemperatureAccessoryPrefix {

        public override void SetDefaults() {
            DisplayName.SetDefault("Shaded");
        }

        public override void ModifyValue(ref float valueMult) {
            valueMult += 0.125f;
        }

        public override float GetSunExtremityChange(Player player) => -0.1f;
    }
}