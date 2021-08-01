using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using TerraTemp.Common.Systems;
using TerraTemp.Custom.Interfaces;

namespace TerraTemp.Content.Changes {

    /// <summary>
    /// Class that handles if something will change based on a given players adjacency to any given tile.
    /// </summary>
    public abstract class AdjacencyChange : ITempStatChange, ILoadable {

        /// <summary>
        /// The ID(s) of the tile(s) that will have the changes applied when the player is adjacent
        /// to them.
        /// </summary>
        public virtual List<int> AppliedTileIDs => new List<int>();

        /// <summary>
        /// By how much this given item will change the player's Base Desired (Environmental) Temperature.
        /// </summary>
        public virtual float GetDesiredTemperatureChange(Player player) => 0f;

        /// <summary>
        /// By how much this given item will change the player's Relative Humidity.
        /// </summary>
        public virtual float GetHumidityChange(Player player) => 0f;

        /// <summary>
        /// By how much this given item will change the player's Heat Comfortability Range.
        /// </summary>
        public virtual float GetHeatComfortabilityChange(Player player) => 0f;

        /// <summary>
        /// By how much this given item will change the player's Cold Comfortability Range.
        /// </summary>
        public virtual float GetColdComfortabilityChange(Player player) => 0f;

        /// <summary>
        /// By how much this given item will change the player's Temperature Resistance.
        /// </summary>
        public virtual float GetTemperatureResistanceChange(Player player) => 0f;

        /// <summary>
        /// By how much this given item will change the player's critical temperature range.
        /// </summary>
        public virtual float GetCriticalTemperatureChange(Player player) => 0f;

        /// <summary>
        /// By how much this given item will change the player's climate extremity value.
        /// </summary>
        public virtual float GetClimateExtremityChange(Player player) => 0f;

        /// <summary>
        /// By how much this given item will change the player's sun extremity value (sun
        /// protection, essentially).
        /// </summary>
        public virtual float GetSunExtremityChange(Player player) => 0f;

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

        public void Load(Mod mod) {
            ContentListSystem.adjacencyChanges.Add((AdjacencyChange)Activator.CreateInstance(GetType()));
        }

        public void Unload() { }
    }
}