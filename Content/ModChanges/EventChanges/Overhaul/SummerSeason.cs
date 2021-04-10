using Terraria;
using TerraTemp.Custom.Attributes;
using TerraTemp.Custom.Classes.ReflectionMod;

namespace TerraTemp.Content.ModChanges.EventChanges.Overhaul {

    [PertainedMod(typeof(OverhaulMod))]
    public class SummerSeason : ModEvent {

        public SummerSeason(ReflectionMod reflectionModInstance) : base(reflectionModInstance) { }

        public override float GetSunExtremityChange(Player player) => 0.5f;

        public override bool ApplyEventEffects(Player player) {
            //Since TerraTemp is literally a temperature mod, we can disable the temperature system in Overhaul
            player.buffImmune[reflectionModInstance.ModInstance.BuffType("HOT")] = true;
            player.buffImmune[reflectionModInstance.ModInstance.BuffType("OVERHEAT")] = true;
            return (reflectionModInstance as OverhaulMod).IsSeasonOccuring(OverhaulMod.SeasonID.Summer);
        }
    }
}