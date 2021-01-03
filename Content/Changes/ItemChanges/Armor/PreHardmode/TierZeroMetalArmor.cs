using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class TierZeroMetalHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.TinHelmet,
            ItemID.CopperHelmet
        };

        public override float ColdComfortabilityChange => -1f;

        public override float HeatComfortabilityChange => -1f;
    }

    public class TierZeroMetalChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.TinChainmail,
            ItemID.CopperChainmail
        };

        public override float ColdComfortabilityChange => -2f;

        public override float HeatComfortabilityChange => -1f;
    }

    public class TierZeroMetalLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.TinGreaves,
            ItemID.CopperGreaves
        };

        public override float ColdComfortabilityChange => -1f;

        public override float HeatComfortabilityChange => -1f;
    }
}