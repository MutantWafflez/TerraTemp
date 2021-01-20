using Terraria;
using TerraTemp.Custom.Attributes;
using TerraTemp.Custom.Classes.ReflectionMod;

namespace TerraTemp.Content.ModChanges.EventChanges.VariousWeathers {

    [PertainedMod(typeof(VariousWeathersMod))]
    public class HeatWave : ModEvent {
        public override float DesiredTemperatureChange => 7f;

        public HeatWave(ReflectionMod reflectionModInstance) : base(reflectionModInstance) { }

        public override bool ApplyEventEffects(Player player) => (reflectionModInstance as VariousWeathersMod).IsEventOccuring(VariousWeathersMod.VariousWeatherEventID.HeatWave);
    }
}