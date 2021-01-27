using Terraria;
using TerraTemp.Custom.Attributes;
using TerraTemp.Custom.Classes.ReflectionMod;

namespace TerraTemp.Content.ModChanges.EventChanges.Calamity {

    [PertainedMod(typeof(CalamityMod))]
    public class CalamityTemperature : ModEvent {

        public CalamityTemperature(ReflectionMod reflectionModInstance) : base(reflectionModInstance) { }

        public override bool ApplyEventEffects(Player player) {
            (reflectionModInstance as CalamityMod).RemoveDeathModeTemperatureSystem(player);
            return base.ApplyEventEffects(player);
        }
    }
}