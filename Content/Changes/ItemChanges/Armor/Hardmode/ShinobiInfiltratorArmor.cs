using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class ShinobiInfiltratorHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.MonkAltHead
        };
    }

    public class ShinobiInfiltratorChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.MonkAltShirt
        };
    }

    public class ShinobiInfiltratorLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.MonkAltPants
        };
    }

    public class ShinobiInfiltratorArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.MonkAltHead
        };

        public override int ChestPieceID => ItemID.MonkAltShirt;

        public override int LegPieceID => ItemID.MonkAltPants;
    }
}