using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class CelestialStone : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.CelestialStone,
            ItemID.CelestialShell
        };

        public override float HeatComfortabilityChange => 3f;

        public override float ColdComfortabilityChange => -3f;
    }
}