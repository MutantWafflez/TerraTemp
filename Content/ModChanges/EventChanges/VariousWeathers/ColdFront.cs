using System;
using Terraria;
using TerraTemp.Custom.Attributes;
using TerraTemp.Custom.Classes.ReflectionMod;

namespace TerraTemp.Content.ModChanges.EventChanges.VariousWeathers {

    [PertainedMod(typeof(VariousWeathersMod))]
    public class ColdFront : ModEvent {
        public override float DesiredTemperatureChange => -7f;

        public ColdFront(ReflectionMod reflectionModInstance) : base(reflectionModInstance) { }

        public override bool ApplyEventEffects(Player player) => (reflectionModInstance as VariousWeathersMod).IsEventOccuring(VariousWeathersMod.VariousWeatherEventID.ColdFront);
    }
}