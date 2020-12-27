using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class WormScarf : ItemChange {

        public override List<int> AppliedItemIDs => new List<int> {
            ItemID.WormScarf
        };

        public override float ColdComfortabilityChange => -2f;
    }
}