using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class TikiHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.TikiMask
        };
    }

    public class TikiChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.TikiShirt
        };
    }

    public class TikiLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.TikiPants
        };
    }

    public class TikiArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.TikiMask
        };

        public override int ChestPieceID => ItemID.TikiShirt;

        public override int LegPieceID => ItemID.TikiPants;
    }
}