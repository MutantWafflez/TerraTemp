using Terraria;

namespace TerraTemp.Content.Changes.EventChanges {

    public class RainEvent : EventChange {
        public override bool EventBoolean => Main.raining;

        public override float HumidityChange => 1f;

        public override bool ApplyEventEffects(Player player) => player.ZoneOverworldHeight;
    }
}