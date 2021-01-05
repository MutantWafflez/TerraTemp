using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class LavaCharm : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int> {
            ItemID.LavaCharm,
            ItemID.LavaWaders
        };

        public override float HeatComfortabilityChange => 5f;
    }
}