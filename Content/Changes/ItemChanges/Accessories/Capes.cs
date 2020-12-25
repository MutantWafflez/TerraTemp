using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class Capes : ItemChange {
        public override int AppliedItemID => ItemID.CrimsonCloak;

        public override List<int> AlternativeIDs => new List<int> {
            ItemID.MysteriousCape,
            ItemID.RedCape,
            ItemID.WinterCape
        };

        public override float ColdComfortabilityChange => -5f;
    }
}