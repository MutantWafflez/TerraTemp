using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class MythrilHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.MythrilHelmet,
            ItemID.MythrilHat,
            ItemID.MythrilHood
        };
    }

    public class MythrilChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.MythrilChainmail
        };
    }

    public class MythrilLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.MythrilGreaves
        };
    }

    public class MythrilArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.MythrilHelmet,
            ItemID.MythrilHat,
            ItemID.MythrilHood
        };

        public override int ChestPieceID => ItemID.MythrilChainmail;

        public override int LegPieceID => ItemID.MythrilGreaves;
    }
}