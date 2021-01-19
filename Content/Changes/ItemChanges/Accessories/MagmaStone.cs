using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class MagmaStone : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MagmaStone
        };

        public override bool DerivedItemsProvideEffects => true;

        public override float DesiredTemperatureChange => 3f;
    }
}