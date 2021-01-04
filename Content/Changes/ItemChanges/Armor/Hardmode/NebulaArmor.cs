using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class NebulaHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.NebulaHelmet
        };
    }

    public class NebulaChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.NebulaBreastplate
        };
    }

    public class NebulaLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.NebulaLeggings
        };
    }

    public class NebulaArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.NebulaHelmet
        };

        public override int ChestPieceID => ItemID.NebulaBreastplate;

        public override int LegPieceID => ItemID.NebulaLeggings;
    }
}