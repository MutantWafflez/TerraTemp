using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class PalladiumHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.PalladiumHelmet,
            ItemID.PalladiumHeadgear,
            ItemID.PalladiumMask
        };
    }

    public class PalladiumChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.PalladiumBreastplate
        };
    }

    public class PalladiumLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.PalladiumLeggings
        };
    }

    public class PalladiumArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.PalladiumHelmet,
            ItemID.PalladiumHeadgear,
            ItemID.PalladiumMask
        };

        public override int ChestPieceID => ItemID.PalladiumBreastplate;

        public override int LegPieceID => ItemID.PalladiumLeggings;
    }
}