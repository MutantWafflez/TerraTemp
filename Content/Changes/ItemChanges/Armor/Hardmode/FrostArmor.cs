using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class FrostHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.FrostHelmet
        };
    }

    public class FrostChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.FrostBreastplate
        };
    }

    public class FrostLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.FrostLeggings
        };
    }

    public class FrostArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.FrostHelmet
        };

        public override int ChestPieceID => ItemID.FrostBreastplate;

        public override int LegPieceID => ItemID.FrostLeggings;
    }
}