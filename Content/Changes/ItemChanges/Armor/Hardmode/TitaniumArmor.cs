using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class TitaniumHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.TitaniumHelmet,
            ItemID.TitaniumMask,
            ItemID.TitaniumHeadgear
        };
    }

    public class TitaniumChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.TitaniumBreastplate
        };
    }

    public class TitaniumLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.TitaniumLeggings
        };
    }

    public class TitaniumArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.TitaniumHelmet,
            ItemID.TitaniumMask,
            ItemID.TitaniumHeadgear
        };

        public override int ChestPieceID => ItemID.TitaniumBreastplate;

        public override int LegPieceID => ItemID.TitaniumLeggings;
    }
}