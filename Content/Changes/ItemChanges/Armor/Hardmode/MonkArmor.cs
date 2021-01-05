using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class MonkHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MonkBrows
        };
    }

    public class MonkChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MonkShirt
        };
    }

    public class MonkLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MonkPants
        };
    }

    public class MonkArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.MonkBrows
        };

        public override int ChestPieceID => ItemID.MonkShirt;

        public override int LegPieceID => ItemID.MonkPants;
    }
}