using Terraria;

namespace TerraTemp.Content.Changes.EventChanges {

    public class BloodmoonEvent : EventChange {
        public override bool EventBoolean => Main.bloodMoon;

        public override float DesiredTemperatureChange => 8f;

        public override float HumidityChange => 0.34f;

        public override bool ApplyEventEffects(Player player) => player.ZoneOverworldHeight;
    }
}