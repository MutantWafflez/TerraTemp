using System.Collections.Generic;
using Terraria.ID;
using TerraTemp.Content.Changes.BuffChanges.Buffs;
using TerraTemp.Custom;

namespace TerraTemp.Content.Changes.ItemChanges.Potions {

    public class EndurancePotion : ItemChange {
        private readonly EnduranceBuff enduranceBuff = new EnduranceBuff();

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.EndurancePotion
        };

        public override string AdditionalTooltip => TempUtilities.GetTerraTempTextValue("GlobalTooltip.IncreasedTempResistance", enduranceBuff.TemperatureResistanceChange * 100f);
    }
}