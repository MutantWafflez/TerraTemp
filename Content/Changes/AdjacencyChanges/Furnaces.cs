using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.AdjacencyChanges {

    public class Furnaces : AdjacencyChange {

        public override List<int> AppliedTileIDs => new List<int>() {
            TileID.Furnaces,
            TileID.Hellforge,
            TileID.AdamantiteForge,
            TileID.LihzahrdFurnace,
            TileID.GlassKiln
        };

        public override float GetDesiredTemperatureChange(Player player) => 3f;
    }
}