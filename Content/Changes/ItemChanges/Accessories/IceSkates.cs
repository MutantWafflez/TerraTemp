using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class IceSkates : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.IceSkates,
            ItemID.ArcticDivingGear,
            ItemID.FrostsparkBoots
        };

        public override float ColdComfortabilityChange => -3f;
    }
}