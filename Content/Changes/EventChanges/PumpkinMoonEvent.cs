using Terraria;

namespace TerraTemp.Content.Changes.EventChanges {

    public class PumpkinMoonEvent : EventChange {
        public override bool EventBoolean => Main.pumpkinMoon;

        public override float GetDesiredTemperatureChange(Player player) => -5f;
    }
}