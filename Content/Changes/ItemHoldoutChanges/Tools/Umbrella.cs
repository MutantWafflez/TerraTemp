using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemHoldoutChanges.Tools {

    public class Umbrella : ItemHoldoutChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.Umbrella
        };

        public override float GetSunExtremityChange(Player player) => -0.34f;
    }
}