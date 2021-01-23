using Terraria;
using TerraTemp.Custom.Attributes;
using TerraTemp.Custom.Classes.ReflectionMod;

namespace TerraTemp.Content.ModChanges.EventChanges.VariousWeathers {

    [PertainedMod(typeof(VariousWeathersMod))]
    public class HailEvent : ModEvent {

        public HailEvent(ReflectionMod reflectionModInstance) : base(reflectionModInstance) { }

        public override float GetDesiredTemperatureChange(Player player) => -5f;

        public override bool ApplyEventEffects(Player player) => player.ZoneOverworldHeight && !player.ZoneDesert && (reflectionModInstance as VariousWeathersMod).IsEventOccuring(VariousWeathersMod.VariousWeatherEventID.Hail);
    }
}