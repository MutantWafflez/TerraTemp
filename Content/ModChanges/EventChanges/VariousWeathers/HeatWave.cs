using Terraria;
using TerraTemp.Custom.Attributes;
using TerraTemp.Custom.Classes.ReflectionMod;

namespace TerraTemp.Content.ModChanges.EventChanges.VariousWeathers {

    [PertainedMod(typeof(VariousWeathersMod))]
    public class HeatWave : ModEvent {

        public HeatWave(ReflectionMod reflectionModInstance) : base(reflectionModInstance) { }

        public override float GetDesiredTemperatureChange(Player player) => 7f;

        public override bool ApplyEventEffects(Player player) => (reflectionModInstance as VariousWeathersMod).IsEventOccuring(VariousWeathersMod.VariousWeatherEventID.HeatWave);
    }
}