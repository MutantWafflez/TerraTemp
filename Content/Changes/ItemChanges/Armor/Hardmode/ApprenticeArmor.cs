using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class ApprenticeHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ApprenticeHat
        };
    }

    public class ApprenticeChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ApprenticeRobe
        };
    }

    public class ApprenticeLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ApprenticeTrousers
        };
    }

    public class ApprenticeArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.ApprenticeHat
        };

        public override int ChestPieceID => ItemID.ApprenticeRobe;

        public override int LegPieceID => ItemID.ApprenticeTrousers;
    }
}