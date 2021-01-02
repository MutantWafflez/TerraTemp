using System.Collections.Generic;
using Terraria.ID;
using TerraTemp.Content.Changes.BuffChanges.Buffs;

namespace TerraTemp.Content.Changes.ItemChanges.Potions {

    public class WarmthPotion : ItemChange {
        private readonly WarmthBuff warmthChange = new WarmthBuff();

        public override List<int> AppliedItemIDs => new List<int> {
            ItemID.WarmthPotion
        };

        public override float ColdComfortabilityChange => warmthChange.ColdComfortabilityChange;
    }
}