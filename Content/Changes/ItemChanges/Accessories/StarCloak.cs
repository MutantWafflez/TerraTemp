using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class StarCloak : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.StarCloak
        };

        public override bool DerivedItemsProvideEffects => true;

        public override float ColdComfortabilityChange => -3f;
    }
}