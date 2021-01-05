using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class SquireHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SquireGreatHelm
        };
    }

    public class SquireChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SquirePlating
        };
    }

    public class SquireLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SquireGreaves
        };
    }

    public class SquireArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.SquireGreatHelm
        };

        public override int ChestPieceID => ItemID.SquirePlating;

        public override int LegPieceID => ItemID.SquireGreaves;
    }
}