using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class SunStone : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SunStone
        };

        //public override bool DerivedItemsProvideEffects => true;

        public override float GetHeatComfortabilityChange(Player player) => 3f;
    }
}