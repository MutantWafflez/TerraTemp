using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class Handwarmer : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.HandWarmer
        };

        public override float ColdComfortabilityChange => -3f;
    }
}