using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class MonkHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.MonkBrows
        };
    }

    public class MonkChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.MonkShirt
        };
    }

    public class MonkLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.MonkPants
        };
    }

    public class MonkArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.MonkBrows
        };

        public override int ChestPieceID => ItemID.MonkShirt;

        public override int LegPieceID => ItemID.MonkPants;
    }
}