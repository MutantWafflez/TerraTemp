using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class PhilosopherStone : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.PhilosophersStone
        };

        //public override bool DerivedItemsProvideEffects => true;

        public override float GetTemperatureResistanceChange(Player player) => 0.15f;
    }
}