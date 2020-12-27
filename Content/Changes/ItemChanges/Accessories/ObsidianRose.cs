using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class ObsidianRose : ItemChange {

        public override List<int> AppliedItemIDs => new List<int> {
            ItemID.ObsidianRose
        };

        public override string AdditionalTooltip => "Negates the temperature increase of touching and being near lava";
    }
}