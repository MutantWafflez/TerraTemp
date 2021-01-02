using System;
using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class EskimoHat : ItemChange {

        public override List<int> AppliedItemIDs => new List<int> {
            ItemID.EskimoHood,
            ItemID.PinkEskimoHood
        };

        public override float ColdComfortabilityChange => -2f;
    }

    public class EskimoShirt : ItemChange {

        public override List<int> AppliedItemIDs => new List<int> {
            ItemID.EskimoCoat,
            ItemID.PinkEskimoCoat
        };

        public override float ColdComfortabilityChange => -3f;
    }

    public class EskimoPants : ItemChange {

        public override List<int> AppliedItemIDs => new List<int> {
            ItemID.EskimoPants,
            ItemID.PinkEskimoPants
        };

        public override float ColdComfortabilityChange => -2f;
    }

    public class EskimoSetBonus : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.EskimoHood
        };

        public override int ChestPieceID => ItemID.EskimoCoat;

        public override int LegPieceID => ItemID.EskimoPants;

        public override string ArmorSetName => "EskimoArmorSet";

        public override float CriticalTemperatureChange => 2f;
    }

    public class PinkEskimoSetBonus : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.PinkEskimoHood
        };

        public override int ChestPieceID => ItemID.PinkEskimoCoat;

        public override int LegPieceID => ItemID.PinkEskimoPants;

        public override string ArmorSetName => "PinkEskimoArmorSet";

        public override float CriticalTemperatureChange => 2f;
    }
}