using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.AdjacencyChanges {

    public class Campfires : AdjacencyChange {

        public override List<int> AppliedTileIDs => new List<int>() {
            TileID.Campfire,
            TileID.Fireplace
        };

        public override float DesiredTemperatureChange => 3f;
    }
}