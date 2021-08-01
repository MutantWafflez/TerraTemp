using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Content.Changes.Climates;
using TerraTemp.Custom;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class ObsidianSkull : ItemChange {
        private readonly UnderworldClimate underworldClimate = new UnderworldClimate();

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ObsidianSkull,
            ItemID.LavaSkull,
            ItemID.MoltenCharm,
            ItemID.ObsidianHorseshoe,
            ItemID.ObsidianShield,
            ItemID.AnkhShield,
            ItemID.ObsidianSkullRose,
            ItemID.MoltenSkullRose,
            ItemID.ObsidianWaterWalkingBoots,
            ItemID.LavaWaders,
            ItemID.TerrasparkBoots
        };

        public override bool DerivedItemsProvideEffects => true;

        public override float GetHeatComfortabilityChange(Player player) => 2f;

        public override void AdditionalItemEquipEffect(Player player) {
            if (player.ZoneUnderworldHeight) {
                player.GetTempPlayer().baseDesiredTemperature -= underworldClimate.GetDesiredTemperatureChange(player) * 0.5f;
            }
        }
    }
}