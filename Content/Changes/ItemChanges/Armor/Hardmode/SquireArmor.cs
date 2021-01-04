using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class SquireHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.SquireGreatHelm
        };
    }

    public class SquireChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.SquirePlating
        };
    }

    public class SquireLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.SquireGreaves
        };
    }

    public class SquireArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.SquireGreatHelm
        };

        public override int ChestPieceID => ItemID.SquirePlating;

        public override int LegPieceID => ItemID.SquireGreaves;
    }
}