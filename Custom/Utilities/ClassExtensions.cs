using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Utilities;
using TerraTemp.Common.Players;

namespace TerraTemp.Custom.Utilities {

    /// <summary>
    /// Class that holds all the extension methods for other classes.
    /// </summary>
    public static class ClassExtensions {

        /// <summary>
        /// Shorthand method that returns the given player's TempPlayer ModPlayer.
        /// </summary>
        public static TempPlayer GetTempPlayer(this Player player) => player.GetModPlayer<TempPlayer>();

        /// <summary>
        /// Returns whether or not this given player is under a roof. Being "under a roof"
        /// constitutes that there are two blocks somewhere at least 32 blocks above the player.
        /// </summary>
        public static bool IsUnderRoof(this Player player) {
            return !Collision.CanHitLine(new Vector2(player.Center.X + 8f, player.Top.Y), 4, 4, new Vector2(player.Center.X + 8f, player.Top.Y - 16 * 33), 4, 4) && !Collision.CanHitLine(new Vector2(player.Center.X - 8f, player.Top.Y), 4, 4, new Vector2(player.Center.X - 8f, player.Top.Y - 16 * 33), 4, 4);
        }

        /// <summary>
        /// Returns whether or not this given player is considered to be "indoors." They must be
        /// under a roof and have a back wall on them to be considered indoors.
        /// </summary>
        public static bool IsIndoors(this Player player) {
            return player.IsUnderRoof() && player.behindBackWall;
        }

        /// <summary>
        /// Adds the given object to this <see cref="WeightedRandom{T}"/> if the condition is true.
        /// </summary>
        /// <param name="list"> The list that will be added to. </param>
        /// <param name="thing"> The thing that will be added to the list. </param>
        /// <param name="condition">
        /// The condition unto which the thing will be added to this list.
        /// </param>
        /// <param name="weight"> The weight of the given thing being added to the weighted random. </param>
        public static void ConditionallyAdd<T>(this WeightedRandom<T> list, T thing, bool condition, double weight = 1) {
            if (condition) {
                list.Add(thing, weight);
            }
        }

        /// <summary>
        /// Shifts the given array left by one index. The last index in the array is set to the
        /// default value of it's type.
        /// </summary>
        public static void DestructivelyShiftLeftOne<T>(this T[] array) {
            for (int i = 0; i < array.Length - 1; i++) {
                array[i] = array[i + 1];
            }

            array[^1] = default;
        }
    }
}