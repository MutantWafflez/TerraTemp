using Terraria;
using TerraTemp.Custom.Attributes;
using TerraTemp.Custom.Classes.ReflectionMod;

namespace TerraTemp.Content.ModChanges.EventChanges.VariousWeathers {

    [PertainedMod(typeof(VariousWeathersMod))]
    public class HoneyRain : ModEvent {

        public HoneyRain(ReflectionMod reflectionModInstance) : base(reflectionModInstance) { }

        public override float GetHumidityChange(Player player) => -0.34f;

        public override bool ApplyEventEffects(Player player) => player.ZoneOverworldHeight && player.ZoneJungle && (reflectionModInstance as VariousWeathersMod).IsEventOccuring(VariousWeathersMod.VariousWeatherEventID.HoneyRain);
    }
}