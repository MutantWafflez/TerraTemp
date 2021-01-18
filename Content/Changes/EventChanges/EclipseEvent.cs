using Terraria;

namespace TerraTemp.Content.Changes.EventChanges {

    public class EclipseEvent : EventChange {
        public override bool EventBoolean => Main.eclipse;

        public override float DesiredTemperatureChange => 5f;

        public override float HumidityChange => 0.45f;

        public override bool ApplyEventEffects(Player player) => player.ZoneOverworldHeight;
    }
}