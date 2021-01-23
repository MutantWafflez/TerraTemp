using Terraria;
using TerraTemp.Custom.Attributes;
using TerraTemp.Custom.Classes.ReflectionMod;

namespace TerraTemp.Content.ModChanges.EventChanges.VariousWeathers {

    [PertainedMod(typeof(VariousWeathersMod))]
    public class HeatWave : ModEvent {

        public HeatWave(ReflectionMod reflectionModInstance) : base(reflectionModInstance) { }

        public override float GetDesiredTemperatureChange(Player player) => 7f;

        public override bool ApplyEventEffects(Player player) {
            //Various Weathers mod applies a "Heat Stroke" debuff on the player, and that will cause additional pain then what is necessary (since we increase temperature here)
            //Thus, player becomes immune to it while the Heat Wave is going on.
            player.buffImmune[reflectionModInstance.ModInstance.BuffType("Heatstroke")] = true;
            return player.ZoneOverworldHeight && (reflectionModInstance as VariousWeathersMod).IsEventOccuring(VariousWeathersMod.VariousWeatherEventID.HeatWave);
        }
    }
}