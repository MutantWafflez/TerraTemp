using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemHoldoutChanges.Tools {

    public class IceTorchHoldout : ItemHoldoutChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.IceTorch
        };

        public override float GetDesiredTemperatureChange(Player player) => -2f;
    }
}