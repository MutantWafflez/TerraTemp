using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class FlurryBoots : ItemChange {
        //TODO: When porting to 1.4, don't forget to add Dune Rider boots

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.FlurryBoots
        };

        public override float ColdComfortabilityChange => -2f;
    }
}