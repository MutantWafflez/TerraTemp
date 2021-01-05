using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class TierTwoMetalHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SilverHelmet,
            ItemID.TungstenHelmet
        };

        public override float ColdComfortabilityChange => -1.5f;

        public override float HeatComfortabilityChange => -1f;
    }

    public class TierTwoMetalChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SilverChainmail,
            ItemID.TungstenChainmail
        };

        public override float ColdComfortabilityChange => -2.5f;

        public override float HeatComfortabilityChange => -1f;
    }

    public class TierTwoMetalLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SilverGreaves,
            ItemID.TungstenGreaves
        };

        public override float ColdComfortabilityChange => -1.5f;

        public override float HeatComfortabilityChange => -1f;
    }
}