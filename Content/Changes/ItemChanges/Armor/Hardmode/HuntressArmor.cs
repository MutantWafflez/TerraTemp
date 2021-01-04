using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class HuntressHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.HuntressWig
        };
    }

    public class HuntressChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.HuntressJerkin
        };
    }

    public class HuntressLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.HuntressPants
        };
    }

    public class HuntressArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.HuntressWig
        };

        public override int ChestPieceID => ItemID.HuntressJerkin;

        public override int LegPieceID => ItemID.HuntressPants;
    }
}