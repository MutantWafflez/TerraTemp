using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class SpiderHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.SpiderMask
        };
    }

    public class SpiderChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.SpiderBreastplate
        };
    }

    public class SpiderLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.SpiderGreaves
        };
    }

    public class SpiderArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.SpiderMask
        };

        public override int ChestPieceID => ItemID.SpiderBreastplate;

        public override int LegPieceID => ItemID.SpiderGreaves;
    }
}