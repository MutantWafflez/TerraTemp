using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class PharaohHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.PharaohsMask
        };

        public override float GetHeatComfortabilityChange(Player player) => 0.5f;
    }

    public class PharaohChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.PharaohsRobe
        };

        public override float GetHeatComfortabilityChange(Player player) => 0.5f;
    }

    public class PharaohArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.PharaohsMask
        };

        public override int ChestPieceID => ItemID.PharaohsRobe;

        public override float GetHeatComfortabilityChange(Player player) => 2f;
    }
}