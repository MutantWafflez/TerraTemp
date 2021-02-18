using Terraria;
using TerraTemp.Custom.Attributes;
using TerraTemp.Custom.Classes.ReflectionMod;

namespace TerraTemp.Content.ModChanges.EventChanges.Overhaul {

    [PertainedMod(typeof(OverhaulMod))]
    public class SummerSeason : ModEvent {

        public SummerSeason(ReflectionMod reflectionModInstance) : base(reflectionModInstance) { }

        public override float GetSunExtremityChange(Player player) => 0.34f;

        public override bool ApplyEventEffects(Player player) {
            //Since TerraTemp is literally a temperature mod, we can disable the temperature system in Overhaul
            //player.buffImmune[reflectionModInstance.ModInstance.BuffType("HOT")] = true; TODO: Fix crossmod with becoming immune to modded buffs
            //player.buffImmune[reflectionModInstance.ModInstance.BuffType("OVERHEAT")] = true;
            return (reflectionModInstance as OverhaulMod).IsSeasonOccuring(OverhaulMod.SeasonID.Summer);
        }
    }
}