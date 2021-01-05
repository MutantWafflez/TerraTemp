using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class ShinobiInfiltratorHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MonkAltHead
        };
    }

    public class ShinobiInfiltratorChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MonkAltShirt
        };
    }

    public class ShinobiInfiltratorLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MonkAltPants
        };
    }

    public class ShinobiInfiltratorArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.MonkAltHead
        };

        public override int ChestPieceID => ItemID.MonkAltShirt;

        public override int LegPieceID => ItemID.MonkAltPants;
    }
}