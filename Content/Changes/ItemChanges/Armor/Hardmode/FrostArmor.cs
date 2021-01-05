using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class FrostHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.FrostHelmet
        };
    }

    public class FrostChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.FrostBreastplate
        };
    }

    public class FrostLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.FrostLeggings
        };
    }

    public class FrostArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.FrostHelmet
        };

        public override int ChestPieceID => ItemID.FrostBreastplate;

        public override int LegPieceID => ItemID.FrostLeggings;
    }
}