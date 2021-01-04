using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class ChlorophyteHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.ChlorophyteHelmet,
            ItemID.ChlorophyteMask,
            ItemID.ChlorophyteHeadgear
        };
    }

    public class ChlorophyteChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.ChlorophytePlateMail
        };
    }

    public class ChlorophyteLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.ChlorophyteGreaves
        };
    }

    public class ChlorophyteArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.ChlorophyteHelmet,
            ItemID.ChlorophyteMask,
            ItemID.ChlorophyteHeadgear
        };

        public override int ChestPieceID => ItemID.ChlorophytePlateMail;

        public override int LegPieceID => ItemID.ChlorophyteGreaves;
    }
}