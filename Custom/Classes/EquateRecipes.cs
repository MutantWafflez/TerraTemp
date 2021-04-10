using System.Collections.Generic;
using Terraria;

namespace TerraTemp.Custom.Classes {

    /// <summary>
    /// Comparer class that determines if two recipes create the same item.
    /// </summary>
    public class RecipeProductComparer : IEqualityComparer<Recipe> {

        public bool Equals(Recipe x, Recipe y) {
            //Check whether the compared objects reference the same data.
            if (ReferenceEquals(x, y)) {
                return true;
            }

            //Check whether any of the compared objects is null.
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) {
                return false;
            }

            return x.createItem.type == y.createItem.type;
        }

        public int GetHashCode(Recipe obj) {
            return obj.GetHashCode();
        }
    }
}