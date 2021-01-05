using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class TitaniumHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.TitaniumHelmet,
            ItemID.TitaniumMask,
            ItemID.TitaniumHeadgear
        };
    }

    public class TitaniumChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.TitaniumBreastplate
        };
    }

    public class TitaniumLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.TitaniumLeggings
        };
    }

    public class TitaniumArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.TitaniumHelmet,
            ItemID.TitaniumMask,
            ItemID.TitaniumHeadgear
        };

        public override int ChestPieceID => ItemID.TitaniumBreastplate;

        public override int LegPieceID => ItemID.TitaniumLeggings;
    }
}