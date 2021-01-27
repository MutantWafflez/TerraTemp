using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Content.Changes.BuffChanges.Buffs;

namespace TerraTemp.Content.Changes.ItemChanges.Potions {

    public class WarmthPotion : ItemChange {
        private readonly WarmthBuff warmthChange = new WarmthBuff();

        public override HashSet<int> AppliedItemIDs => new HashSet<int> {
            ItemID.WarmthPotion
        };

        public override float GetColdComfortabilityChange(Player player) => warmthChange.GetColdComfortabilityChange(player);
    }
}