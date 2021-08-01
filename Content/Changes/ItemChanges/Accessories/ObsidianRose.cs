using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class ObsidianRose : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int> {
            ItemID.ObsidianRose,
            ItemID.ObsidianSkullRose,
            ItemID.MoltenSkullRose,
            ItemID.LavaWaders,
            ItemID.TerrasparkBoots
        };

        public override bool DerivedItemsProvideEffects => true;
    }
}