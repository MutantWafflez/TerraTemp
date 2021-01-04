using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class StardustHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.StardustHelmet
        };
    }

    public class StardustChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.StardustBreastplate
        };
    }

    public class StardustLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.StardustLeggings
        };
    }

    public class StardustArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.StardustHelmet
        };

        public override int ChestPieceID => ItemID.StardustBreastplate;

        public override int LegPieceID => ItemID.StardustLeggings;
    }
}