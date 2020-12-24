using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class LavaCharm : ItemChange {
        public override int AppliedItemID => ItemID.LavaCharm;

        public override List<int> AlternativeIDs => new List<int> {
            ItemID.LavaWaders
        };

        public override float HeatComfortabilityChange => 5f;

        public override string AdditionalTooltip => "5 degree increased heat comfortability range";
    }
}