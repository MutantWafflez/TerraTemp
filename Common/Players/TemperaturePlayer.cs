namespace TerraTemp.Common.Players {
    public class TemperaturePlayer : ModPlayer {
        private const double DefaultBodyTemperature = 36.5d;

        /// <summary>
        /// The player's current temperature.
        /// </summary>
        public double CurrentBodyTemperature {
            get;
            private set;
        }

        public double AmbientTemperature {
            get;
            private set;
        }

        public double AmbientHumidity {
            get;
            private set;
        }

        public override void ResetEffects() {
            AmbientTemperature = DefaultBodyTemperature;
            AmbientHumidity = 0;
        }

        public override void UpdateDead() {
            CurrentBodyTemperature = DefaultBodyTemperature;
        }

        public override void PostUpdate() {
            // TODO: Do numbers testing
            CurrentBodyTemperature += (AmbientTemperature - CurrentBodyTemperature) / 400f;
        }
    }
}