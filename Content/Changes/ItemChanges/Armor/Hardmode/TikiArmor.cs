using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class TikiHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.TikiMask
        };
    }

    public class TikiChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.TikiShirt
        };
    }

    public class TikiLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.TikiPants
        };
    }

    public class TikiArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.TikiMask
        };

        public override int ChestPieceID => ItemID.TikiShirt;

        public override int LegPieceID => ItemID.TikiPants;
    }
}