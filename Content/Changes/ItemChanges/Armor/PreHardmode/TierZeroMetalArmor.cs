using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class TierZeroMetalHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.TinHelmet,
            ItemID.CopperHelmet
        };

        public override float GetColdComfortabilityChange(Player player) => -1f;

        public override float GetHeatComfortabilityChange(Player player) => -1f;
    }

    public class TierZeroMetalChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.TinChainmail,
            ItemID.CopperChainmail
        };

        public override float GetColdComfortabilityChange(Player player) => -2f;

        public override float GetHeatComfortabilityChange(Player player) => -1f;
    }

    public class TierZeroMetalLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.TinGreaves,
            ItemID.CopperGreaves
        };

        public override float GetColdComfortabilityChange(Player player) => -1f;

        public override float GetHeatComfortabilityChange(Player player) => -1f;
    }
}