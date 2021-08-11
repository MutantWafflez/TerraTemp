using System.Collections.Generic;
using System.Linq;
using Terraria;

namespace TerraTemp.Custom.Utilities {

    /// <summary>
    /// Class that has methods dealing with collections, which includes lists predominately.
    /// </summary>
    public static class CollectionUtilities {

        /// <summary>
        /// A more advanced Contains() method for lists that will check whether or not a given list
        /// has any values that is contained in another list. To be precise, <paramref
        /// name="containingList"/> is searched to see if it contains any items from <paramref name="listQuery"/>.
        /// </summary>
        /// <typeparam name="T"> Class of both of the lists. </typeparam>
        /// <param name="containingList"> List to be searched. </param>
        /// <param name="listQuery">
        /// List with potential children to be checked in the <paramref name="containingList"/> list.
        /// </param>
        /// <returns> </returns>
        public static bool ContainsList<T>(List<T> containingList, List<T> listQuery) {
            foreach (T thing in listQuery) {
                if (containingList.Contains(thing)) {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Creates and returns a "Recipe Tree" (a Queue of integers) of item types that contain the
        /// passed in item type ANYWHERE in their crafting tree, if applicable.
        /// </summary>
        /// <param name="typeToFind"> The type to search for. </param>
        public static Queue<int> CreateRecipeTree(int typeToFind) {
            Queue<int> inheritedItems = new Queue<int>();

            foreach (Recipe recipe in Main.recipe) {
                if (recipe.requiredItem.Any(item => item.type == typeToFind)) {
                    inheritedItems.Enqueue(recipe.createItem.type);
                }
            }

            int startingLength;
            do {
                startingLength = inheritedItems.Count;

                Queue<int> placeholderQueue = new Queue<int>();
                foreach (Recipe recipe in Main.recipe) {
                    foreach (int inheritorType in inheritedItems) {
                        if (recipe.requiredItem.Any(item => item.type == inheritorType)) {
                            placeholderQueue.Enqueue(recipe.createItem.type);
                        }
                    }
                }

                foreach (int inheritor in placeholderQueue) {
                    inheritedItems.Enqueue(inheritor);
                }
            } while (inheritedItems.Count < startingLength);

            return inheritedItems;
        }
    }
}