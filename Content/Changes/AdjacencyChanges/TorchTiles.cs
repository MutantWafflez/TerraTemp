using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.AdjacencyChanges {

    public class TorchTiles : AdjacencyChange {

        public override List<int> AppliedTileIDs => new List<int>() {
            TileID.Torches
        };

        public override float GetDesiredTemperatureChange(Player player) => 1f;
    }
}