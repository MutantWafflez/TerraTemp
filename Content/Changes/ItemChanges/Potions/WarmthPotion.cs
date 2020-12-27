using System.Collections.Generic;
using Terraria.ID;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Potions {

    public class WarmthPotion : ItemChange {

        public override List<int> AppliedItemIDs => new List<int> {
            ItemID.WarmthPotion
        };

        public override string AdditionalTooltip => TempUtilities.GetTerraTempTextValue("GlobalTooltip.IncreasedColdComfortability", 8f);
    }
}