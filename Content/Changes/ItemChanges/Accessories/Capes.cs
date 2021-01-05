using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class Capes : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int> {
            ItemID.CrimsonCloak,
            ItemID.MysteriousCape,
            ItemID.RedCape,
            ItemID.WinterCape
        };

        public override float ColdComfortabilityChange => -5f;
    }
}