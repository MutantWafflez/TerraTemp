using Terraria;

namespace TerraTemp.Content.Prefixes.Humidity {

    public class DriedPrefix : TemperatureAccessoryPrefix {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Dried");
        }

        public override void ModifyValue(ref float valueMult) {
            valueMult += 0.125f;
        }

        public override float GetHumidityChange(Player player) => -0.1f;
    }
}