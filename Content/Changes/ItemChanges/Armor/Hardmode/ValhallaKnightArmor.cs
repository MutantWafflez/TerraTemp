using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class ValhallaKnightHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SquireAltHead
        };
    }

    public class ValhallaKnightChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SquireAltShirt
        };
    }

    public class ValhallaKnightLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SquireAltPants
        };
    }

    public class ValhallaKnightArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.SquireAltHead
        };

        public override int ChestPieceID => ItemID.SquireAltShirt;

        public override int LegPieceID => ItemID.SquireAltPants;
    }
}