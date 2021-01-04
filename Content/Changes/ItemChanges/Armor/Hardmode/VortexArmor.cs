using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class VortexHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.VortexHelmet
        };
    }

    public class VortexChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.VortexBreastplate
        };
    }

    public class VortexLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.VortexLeggings
        };
    }

    public class VortexArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.VortexHelmet
        };

        public override int ChestPieceID => ItemID.VortexBreastplate;

        public override int LegPieceID => ItemID.VortexLeggings;
    }
}