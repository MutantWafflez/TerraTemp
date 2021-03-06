﻿using Terraria;
using TerraTemp.Custom.Attributes;
using TerraTemp.Custom.Classes.ReflectionMod;

namespace TerraTemp.Content.ModChanges.EventChanges.Overhaul {

    [PertainedMod(typeof(OverhaulMod))]
    public class WinterSeason : ModEvent {

        public WinterSeason(ReflectionMod reflectionModInstance) : base(reflectionModInstance) { }

        public override float GetSunExtremityChange(Player player) => -0.5f;

        public override bool ApplyEventEffects(Player player) {
            return (reflectionModInstance as OverhaulMod).IsSeasonOccuring(OverhaulMod.SeasonID.Winter);
        }
    }
}