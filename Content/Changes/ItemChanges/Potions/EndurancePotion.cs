using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Content.Changes.BuffChanges.Buffs;

namespace TerraTemp.Content.Changes.ItemChanges.Potions {

    public class EndurancePotion : ItemChange {
        private readonly EnduranceBuff enduranceBuff = new EnduranceBuff();

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.EndurancePotion
        };

        public override float GetTemperatureResistanceChange(Player player) => enduranceBuff.GetTemperatureResistanceChange(player);
    }
}