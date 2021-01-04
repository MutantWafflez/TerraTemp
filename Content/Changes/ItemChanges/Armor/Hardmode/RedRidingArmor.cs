using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class RedRidingHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.HuntressAltHead
        };
    }

    public class RedRidingChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.HuntressAltShirt
        };
    }

    public class RedRidingLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.HuntressAltPants
        };
    }

    public class RedRidingArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.HuntressAltHead
        };

        public override int ChestPieceID => ItemID.HuntressAltShirt;

        public override int LegPieceID => ItemID.HuntressAltPants;
    }
}