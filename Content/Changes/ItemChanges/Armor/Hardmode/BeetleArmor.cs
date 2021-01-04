using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class BeetleHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.BeetleHelmet
        };
    }

    public class BeetleChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.BeetleScaleMail,
            ItemID.BeetleShell
        };
    }

    public class BeetleLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.BeetleLeggings
        };
    }

    public class BeetleDefenseArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.BeetleHelmet,
        };

        public override int ChestPieceID => ItemID.BeetleShell;

        public override int LegPieceID => ItemID.BeetleLeggings;
    }

    public class BeetleOffenseArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.BeetleHelmet,
        };

        public override int ChestPieceID => ItemID.BeetleScaleMail;

        public override int LegPieceID => ItemID.BeetleLeggings;
    }
}