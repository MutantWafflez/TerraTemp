using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class PhilosopherStone : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.PhilosophersStone,
            ItemID.CharmofMyths
        };

        public override float TemperatureResistanceChange => 0.15f;
    }
}