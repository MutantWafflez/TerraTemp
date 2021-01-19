using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class LavaCharm : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int> {
            ItemID.LavaCharm
        };

        public override bool DerivedItemsProvideEffects => true;

        public override float HeatComfortabilityChange => 5f;
    }
}