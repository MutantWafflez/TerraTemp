using Terraria;
using TerraTemp.Custom.Attributes;
using TerraTemp.Custom.Classes.ReflectionMod;

namespace TerraTemp.Content.ModChanges.EventChanges.Overhaul {

    [PertainedMod(typeof(OverhaulMod))]
    public class WinterBlizzard : ModEvent {

        public WinterBlizzard(ReflectionMod reflectionModInstance) : base(reflectionModInstance) { }

        //Desired temperature isn't lowered as much since a combination of factors will cause a great effect (no sun effects, wind speed, etc.)
        public override float GetDesiredTemperatureChange(Player player) => -5f;

        //Completely negates sun effects: the sun would never be visible during a blizzard nor have any effects
        public override float GetSunExtremityChange(Player player) => -10f;

        public override bool ApplyEventEffects(Player player) => Main.raining && !player.behindBackWall && player.ZoneOverworldHeight && ((OverhaulMod)reflectionModInstance).IsSeasonOccuring(OverhaulMod.SeasonID.Winter);
    }
}