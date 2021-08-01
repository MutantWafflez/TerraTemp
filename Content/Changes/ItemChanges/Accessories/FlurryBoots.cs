﻿using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class FlurryBoots : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.FlurryBoots
        };

        public override float GetColdComfortabilityChange(Player player) => -2f;
    }
}