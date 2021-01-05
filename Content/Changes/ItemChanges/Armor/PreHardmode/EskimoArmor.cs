using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class EskimoHat : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int> {
            ItemID.EskimoHood,
            ItemID.PinkEskimoHood
        };

        public override float ColdComfortabilityChange => -2f;
    }

    public class EskimoShirt : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int> {
            ItemID.EskimoCoat,
            ItemID.PinkEskimoCoat
        };

        public override float ColdComfortabilityChange => -3f;
    }

    public class EskimoPants : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int> {
            ItemID.EskimoPants,
            ItemID.PinkEskimoPants
        };

        public override float ColdComfortabilityChange => -2f;
    }

    public class EskimoArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.EskimoHood
        };

        public override int ChestPieceID => ItemID.EskimoCoat;

        public override int LegPieceID => ItemID.EskimoPants;

        public override float CriticalTemperatureChange => 2f;
    }

    public class PinkEskimoArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.PinkEskimoHood
        };

        public override int ChestPieceID => ItemID.PinkEskimoCoat;

        public override int LegPieceID => ItemID.PinkEskimoPants;

        public override float CriticalTemperatureChange => 2f;
    }
}