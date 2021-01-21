using Terraria;
using TerraTemp.Custom;

namespace TerraTemp.Content.Changes.EventChanges {

    public class RainEvent : EventChange {
        public override bool EventBoolean => Main.raining;

        public override float GetHumidityChange(Player player) => TempUtilities.GetRainEffectsOnHumidity();

        public override bool ApplyEventEffects(Player player) => player.ZoneOverworldHeight;
    }
}