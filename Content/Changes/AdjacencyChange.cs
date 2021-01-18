using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes {

    /// <summary>
    /// Class that handles if something will change based on a given players adjacency to any given tile.
    /// </summary>
    public abstract class AdjacencyChange {

        /// <summary>
        /// The ID(s) of the tile(s) that will have the changes applied when the player is adjacent
        /// to them.
        /// </summary>
        public virtual List<int> AppliedTileIDs => new List<int>();

        /// <summary>
        /// By how much this given tile will change the player's Base Desired (Environmental) Temperature.
        /// </summary>
        public virtual float DesiredTemperatureChange => 0f;

        /// <summary>
        /// By how much this given tile will change the player's Heat Comfortability Range.
        /// </summary>
        public virtual float HeatComfortabilityChange => 0f;

        /// <summary>
        /// By how much this given tile will change the player's Cold Comfortability Range.
        /// </summary>
        public virtual float ColdComfortabilityChange => 0f;

        /// <summary>
        /// By how much this given tile will change the player's Temperature Resistance.
        /// </summary>
        public virtual float TemperatureResistanceChange => 0f;

        /// <summary>
        /// By how much this given tile will change the player's critical temperature range.
        /// </summary>
        public virtual float CriticalTemperatureChange => 0f;

        /// <summary>
        /// By how much this given tile will change the player's climate extremity value.
        /// </summary>
        public virtual float ClimateExtremityChange => 0f;

        /// <summary>
        /// Method that loops through all of the specified tile IDs and returns whether or not the
        /// player is near any of them.
        /// </summary>
        /// <param name="player"> The player to check for adjacency. </param>
        public bool CheckForAdjacency(Player player) {
            foreach (int tileID in AppliedTileIDs) {
                if (tileID < player.adjTile.Length && player.adjTile[tileID]) {
                    return true;
                }
            }
            return false;
        }
    }
}