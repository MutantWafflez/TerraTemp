using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class ObsidianRose : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int> {
            ItemID.ObsidianRose
        };

        public override string AdditionalTooltip => "Negates the temperature increase of touching and being near lava";
    }
}