using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class RedRidingHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.HuntressAltHead
        };
    }

    public class RedRidingChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.HuntressAltShirt
        };
    }

    public class RedRidingLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.HuntressAltPants
        };
    }

    public class RedRidingArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.HuntressAltHead
        };

        public override int ChestPieceID => ItemID.HuntressAltShirt;

        public override int LegPieceID => ItemID.HuntressAltPants;
    }
}