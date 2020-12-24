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
}