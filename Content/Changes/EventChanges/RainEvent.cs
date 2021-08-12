using Terraria;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Content.Changes.EventChanges {

    public class RainEvent : EventChange {
        public override bool EventBoolean => Main.raining;

        public override float GetHumidityChange(Player player) => MathUtilities.GetRainEffectsOnHumidity();

        public override bool ApplyEventEffects(Player player) => player.ZoneOverworldHeight;
    }
}