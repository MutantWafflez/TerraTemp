using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class TierOneMetalHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.IronHelmet,
            ItemID.AncientIronHelmet,
            ItemID.LeadHelmet
        };

        public override float ColdComfortabilityChange => -1.25f;

        public override float HeatComfortabilityChange => -1f;
    }

    public class TierOneMetalChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.IronChainmail,
            ItemID.LeadChainmail
        };

        public override float ColdComfortabilityChange => -2.25f;

        public override float HeatComfortabilityChange => -1f;
    }

    public class TierOneMetalLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.IronGreaves,
            ItemID.LeadGreaves
        };

        public override float ColdComfortabilityChange => -1.25f;

        public override float HeatComfortabilityChange => -1f;
    }
}