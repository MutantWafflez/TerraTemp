using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class IceSkates : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.IceSkates
        };

        public override bool DerivedItemsProvideEffects => true;

        public override float GetColdComfortabilityChange(Player player) => -3f;
    }
}