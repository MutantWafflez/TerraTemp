using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class DuneRiderBoots : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SandBoots
        };

        public override float GetHeatComfortabilityChange(Player player) => 2f;
    }
}