using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class AdamantiteHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.AdamantiteHelmet,
            ItemID.AdamantiteMask,
            ItemID.AdamantiteHeadgear
        };
    }

    public class AdamantiteChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.AdamantiteBreastplate
        };
    }

    public class AdamantiteLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.AdamantiteLeggings
        };
    }

    public class AdamantiteArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.AdamantiteHelmet,
            ItemID.AdamantiteMask,
            ItemID.AdamantiteHeadgear
        };

        public override int ChestPieceID => ItemID.AdamantiteBreastplate;

        public override int LegPieceID => ItemID.AdamantiteLeggings;
    }
}