﻿using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories.Wings {

    public class FlameWings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.FlameWings
        };

        public override float GetHeatComfortabilityChange(Player player) => 2f;
    }
}