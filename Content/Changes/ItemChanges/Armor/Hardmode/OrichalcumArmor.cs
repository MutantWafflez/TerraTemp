using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class OrichalcumHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.OrichalcumHelmet,
            ItemID.OrichalcumMask,
            ItemID.OrichalcumHeadgear
        };
    }

    public class OrichalcumChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.OrichalcumBreastplate
        };
    }

    public class OrichalcumLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.OrichalcumLeggings
        };
    }

    public class OrichalcumArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.OrichalcumHelmet,
            ItemID.OrichalcumMask,
            ItemID.OrichalcumHeadgear
        };

        public override int ChestPieceID => ItemID.OrichalcumBreastplate;

        public override int LegPieceID => ItemID.OrichalcumLeggings;
    }
}