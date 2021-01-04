using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class CobaltHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.CobaltHelmet,
            ItemID.CobaltMask,
            ItemID.CobaltHat
        };
    }

    public class CobaltChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.CobaltBreastplate
        };
    }

    public class CobaltLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.CobaltLeggings
        };
    }

    public class CobaltArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.CobaltHelmet,
            ItemID.CobaltMask,
            ItemID.CobaltHat
        };

        public override int ChestPieceID => ItemID.CobaltBreastplate;

        public override int LegPieceID => ItemID.CobaltLeggings;
    }
}