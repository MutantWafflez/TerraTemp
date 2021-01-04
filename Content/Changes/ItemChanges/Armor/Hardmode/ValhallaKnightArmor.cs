using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class ValhallaKnightHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.SquireAltHead
        };
    }

    public class ValhallaKnightChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.SquireAltShirt
        };
    }

    public class ValhallaKnightLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.SquireAltPants
        };
    }

    public class ValhallaKnightArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.SquireAltHead
        };

        public override int ChestPieceID => ItemID.SquireAltShirt;

        public override int LegPieceID => ItemID.SquireAltPants;
    }
}