using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class MoonStone : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MoonStone
        };

        //public override bool DerivedItemsProvideEffects => true;

        public override float GetColdComfortabilityChange(Player player) => -3f;
    }
}