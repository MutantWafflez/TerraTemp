using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class BeetleHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.BeetleHelmet
        };
    }

    public class BeetleChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.BeetleScaleMail,
            ItemID.BeetleShell
        };
    }

    public class BeetleLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.BeetleLeggings
        };
    }

    public class BeetleDefenseArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.BeetleHelmet,
        };

        public override int ChestPieceID => ItemID.BeetleShell;

        public override int LegPieceID => ItemID.BeetleLeggings;
    }

    public class BeetleOffenseArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.BeetleHelmet,
        };

        public override int ChestPieceID => ItemID.BeetleScaleMail;

        public override int LegPieceID => ItemID.BeetleLeggings;
    }
}