using Terraria;
using TerraTemp.Custom.Attributes;
using TerraTemp.Custom.Classes.ReflectionMod;

namespace TerraTemp.Content.ModChanges.EventChanges.VariousWeathers {

    [PertainedMod(typeof(VariousWeathersMod))]
    public class VileDeluge : ModEvent {

        public VileDeluge(ReflectionMod reflectionModInstance) : base(reflectionModInstance) { }

        public override float GetHumidityChange(Player player) => 0.34f;

        public override float GetDesiredTemperatureChange(Player player) => -5f;

        public override bool ApplyEventEffects(Player player) => player.ZoneOverworldHeight && player.ZoneCorrupt && (reflectionModInstance as VariousWeathersMod).IsEventOccuring(VariousWeathersMod.VariousWeatherEventID.VileRain);
    }
}