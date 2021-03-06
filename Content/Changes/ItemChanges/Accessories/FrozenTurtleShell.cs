﻿using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class FrozenTurtleShell : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.FrozenTurtleShell
        };

        public override bool DerivedItemsProvideEffects => true;

        public override float GetDesiredTemperatureChange(Player player) => -3f;
    }
}