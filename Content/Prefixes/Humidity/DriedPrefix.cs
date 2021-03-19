using Terraria;

namespace TerraTemp.Content.Prefixes.Humidity {

    public class DehydratedPrefix : TemperatureAccessoryPrefix {

        public override void SetDefaults() {
            DisplayName.SetDefault("Dehydrated");
        }

        public override float RollChance(Item item) => 0.75f;

        public override void ModifyValue(ref float valueMult) {
            valueMult += 0.25f;
        }

        public override float GetHumidityChange(Player player) => -0.15f;
    }
}