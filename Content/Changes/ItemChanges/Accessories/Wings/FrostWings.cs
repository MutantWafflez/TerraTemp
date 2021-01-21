using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories.Wings {

    public class FrostWings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.FrozenWings
        };

        public override float GetColdComfortabilityChange(Player player) => -2f;
    }
}