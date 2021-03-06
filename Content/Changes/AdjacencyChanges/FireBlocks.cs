﻿using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.AdjacencyChanges {

    public class FireBlocks : AdjacencyChange {

        public override List<int> AppliedTileIDs => new List<int>() {
            TileID.Hellstone,
            TileID.HellstoneBrick,
            TileID.Meteorite
        };

        public override float GetDesiredTemperatureChange(Player player) => 3f;
    }
}