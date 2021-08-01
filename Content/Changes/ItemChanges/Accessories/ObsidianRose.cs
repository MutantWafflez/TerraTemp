using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class ObsidianRose : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int> {
            ItemID.ObsidianRose
        };

        //public override bool DerivedItemsProvideEffects => true;
    }
}