using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemHoldoutChanges.Tools {

    public class TierTwoTorches : ItemHoldoutChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.UltrabrightTorch,
            ItemID.DemonTorch,
            ItemID.CursedTorch,
            ItemID.IchorTorch,
            ItemID.RainbowTorch
        };

        public override float GetDesiredTemperatureChange(Player player) => 2f;
    }
}