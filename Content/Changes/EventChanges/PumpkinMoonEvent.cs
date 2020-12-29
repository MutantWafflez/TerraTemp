using Terraria;

namespace TerraTemp.Content.Changes.EventChanges {

    public class PumpkinMoonEvent : EventChange {
        public override bool EventBoolean => Main.pumpkinMoon;

        public override float DesiredTemperatureChange => -5f;
    }
}