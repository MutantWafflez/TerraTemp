using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class WormScarf : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int> {
            ItemID.WormScarf
        };

        public override float GetColdComfortabilityChange(Player player) => -2f;
    }
}