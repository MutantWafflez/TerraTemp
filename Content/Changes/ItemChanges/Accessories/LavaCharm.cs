using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class LavaCharm : ItemChange {

        public override List<int> AppliedItemIDs => new List<int> {
            ItemID.LavaCharm,
            ItemID.LavaWaders
        };

        public override float HeatComfortabilityChange => 5f;
    }
}