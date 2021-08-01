using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class LavaCharm : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int> {
            ItemID.LavaCharm,
            ItemID.MoltenCharm,
            ItemID.LavaWaders,
            ItemID.HellfireTreads,
            ItemID.TerrasparkBoots
        };

        public override bool DerivedItemsProvideEffects => true;

        public override float GetHeatComfortabilityChange(Player player) => 5f;
    }
}