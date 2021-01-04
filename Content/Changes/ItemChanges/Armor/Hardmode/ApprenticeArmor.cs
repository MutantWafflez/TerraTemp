using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class ApprenticeHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.ApprenticeHat
        };
    }

    public class ApprenticeChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.ApprenticeRobe
        };
    }

    public class ApprenticeLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.ApprenticeTrousers
        };
    }

    public class ApprenticeArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.ApprenticeHat
        };

        public override int ChestPieceID => ItemID.ApprenticeRobe;

        public override int LegPieceID => ItemID.ApprenticeTrousers;
    }
}