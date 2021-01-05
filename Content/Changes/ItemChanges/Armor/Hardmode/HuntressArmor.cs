using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class HuntressHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.HuntressWig
        };
    }

    public class HuntressChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.HuntressJerkin
        };
    }

    public class HuntressLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.HuntressPants
        };
    }

    public class HuntressArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.HuntressWig
        };

        public override int ChestPieceID => ItemID.HuntressJerkin;

        public override int LegPieceID => ItemID.HuntressPants;
    }
}