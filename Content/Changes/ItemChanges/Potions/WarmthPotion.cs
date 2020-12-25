using Terraria.ID;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Potions {

    public class WarmthPotion : ItemChange {
        public override int AppliedItemID => ItemID.WarmthPotion;

        public override string AdditionalTooltip => TempUtilities.GetTerraTempTextValue("GlobalTooltip.IncreasedColdComfortability", 8f);
    }
}