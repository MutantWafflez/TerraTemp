using System;
using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Armor {

    public class EskimoHat : ItemChange {
        public override int AppliedItemID => ItemID.EskimoHood;

        public override List<int> AlternativeIDs => new List<int> {
            ItemID.PinkEskimoHood
        };

        public override float ColdComfortabilityChange => -2f;

        public override string AdditionalTooltip => $"{Math.Abs(ColdComfortabilityChange)} degree increased cold comfortability range";
    }

    public class EskimoShirt : ItemChange {
        public override int AppliedItemID => ItemID.EskimoCoat;

        public override List<int> AlternativeIDs => new List<int> {
            ItemID.PinkEskimoCoat
        };

        public override float ColdComfortabilityChange => -3f;

        public override string AdditionalTooltip => $"{Math.Abs(ColdComfortabilityChange)} degree increased cold comfortability range";
    }

    public class EskimoPants : ItemChange {
        public override int AppliedItemID => ItemID.EskimoPants;

        public override List<int> AlternativeIDs => new List<int> {
            ItemID.PinkEskimoPants
        };

        public override float ColdComfortabilityChange => -2f;

        public override string AdditionalTooltip => $"{Math.Abs(ColdComfortabilityChange)} degree increased cold comfortability range";
    }

    public class EskimoSetBonus : SetBonusChange {
        public override int HelmetPieceID => ItemID.EskimoHood;

        public override int ChestPieceID => ItemID.EskimoCoat;

        public override int LegPieceID => ItemID.EskimoPants;

        public override string ArmorSetName => "EskimoArmorSet";

        public override float CriticalTemperatureChange => 2f;
    }

    public class PinkEskimoSetBonus : SetBonusChange {
        public override int HelmetPieceID => ItemID.PinkEskimoHood;

        public override int ChestPieceID => ItemID.PinkEskimoCoat;

        public override int LegPieceID => ItemID.PinkEskimoPants;

        public override string ArmorSetName => "PinkEskimoArmorSet";

        public override float CriticalTemperatureChange => 2f;
    }
}