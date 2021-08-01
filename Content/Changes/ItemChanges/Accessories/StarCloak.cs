using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class StarCloak : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.StarCloak,
            ItemID.BeeCloak,
            ItemID.ManaCloak,
            ItemID.StarVeil
        };

        public override bool DerivedItemsProvideEffects => true;

        public override float GetColdComfortabilityChange(Player player) => -3f;
    }
}