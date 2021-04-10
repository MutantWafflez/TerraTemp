using Terraria;
using TerraTemp.Custom;
using TerraTemp.Custom.Attributes;
using TerraTemp.Custom.Classes.ReflectionMod;

namespace TerraTemp.Content.ModChanges.EventChanges.Overhaul {

    [PertainedMod(typeof(OverhaulMod))]
    public class WinterBlizzard : ModEvent {

        public WinterBlizzard(ReflectionMod reflectionModInstance) : base(reflectionModInstance) { }

        public override float GetDesiredTemperatureChange(Player player) => -6f;

        //Completely negates sun effects since the sun would be entirely blocked at that point
        public override float GetSunExtremityChange(Player player) => -10f;

        public override bool ApplyEventEffects(Player player) => Main.raining &&
                                                                 !player.ZoneDesert &&
                                                                 !player.ZoneJungle &&
                                                                 !player.IsIndoors() &&
                                                                 player.ZoneOverworldHeight &&
                                                                 ((OverhaulMod)reflectionModInstance).IsSeasonOccuring(OverhaulMod.SeasonID.Winter);
    }
}