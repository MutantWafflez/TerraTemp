using Terraria;

namespace TerraTemp.Content.Changes.EventChanges {

    public class FrostMoonEvent : EventChange {
        public override bool EventBoolean => Main.snowMoon;

        public override float GetDesiredTemperatureChange(Player player) => -10f;
    }
}