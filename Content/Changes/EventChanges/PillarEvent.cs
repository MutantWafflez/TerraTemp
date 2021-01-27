using Terraria;

namespace TerraTemp.Content.Changes.EventChanges {

    public class SolarPillar : EventChange {
        public override bool EventBoolean => true;

        public override float GetDesiredTemperatureChange(Player player) => 6f;

        public override bool ApplyEventEffects(Player player) => player.ZoneTowerSolar;
    }

    public class VortexPillar : EventChange {
        public override bool EventBoolean => true;

        public override float GetDesiredTemperatureChange(Player player) => -6f;

        public override bool ApplyEventEffects(Player player) => player.ZoneTowerVortex;
    }

    public class NebulaPillar : EventChange {
        public override bool EventBoolean => true;

        public override float GetHumidityChange(Player player) => 0.75f;

        public override bool ApplyEventEffects(Player player) => player.ZoneTowerNebula;
    }

    public class StardustPillar : EventChange {
        public override bool EventBoolean => true;

        public override float GetTemperatureResistanceChange(Player player) => -0.75f;

        public override bool ApplyEventEffects(Player player) => player.ZoneTowerStardust;
    }
}