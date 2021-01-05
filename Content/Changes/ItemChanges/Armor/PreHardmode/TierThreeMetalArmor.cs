using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class TierThreeMetalHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.GoldHelmet,
            ItemID.AncientGoldHelmet,
            ItemID.PlatinumHelmet
        };

        public override float ColdComfortabilityChange => -1.75f;

        public override float HeatComfortabilityChange => -1f;
    }

    public class TierThreeMetalChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.GoldChainmail,
            ItemID.PlatinumChainmail
        };

        public override float ColdComfortabilityChange => -3f;

        public override float HeatComfortabilityChange => -1f;
    }

    public class TierThreeMetalLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.GoldGreaves,
            ItemID.PlatinumGreaves
        };

        public override float ColdComfortabilityChange => -1.75f;

        public override float HeatComfortabilityChange => -1f;
    }
}