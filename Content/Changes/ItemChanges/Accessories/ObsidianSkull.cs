using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class ObsidianSkull : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ObsidianSkull,
            ItemID.ObsidianWaterWalkingBoots,
            ItemID.ObsidianShield,
            ItemID.AnkhShield
        };

        public override float HeatComfortabilityChange => 2f;
    }
}