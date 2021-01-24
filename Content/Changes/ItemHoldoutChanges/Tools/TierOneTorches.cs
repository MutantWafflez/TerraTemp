using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemHoldoutChanges.Tools {

    public class TierOneTorches : ItemHoldoutChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.Torch,
            ItemID.PurpleTorch,
            ItemID.YellowTorch,
            ItemID.BlueTorch,
            ItemID.GreenTorch,
            ItemID.RedTorch,
            ItemID.OrangeTorch,
            ItemID.WhiteTorch,
            ItemID.IceTorch,
            ItemID.PinkTorch,
            ItemID.BoneTorch
        };

        public override float GetDesiredTemperatureChange(Player player) => 1f;
    }
}