using System;

namespace TerraTemp.Custom.Structs {

    /// <summary>
    /// Struct that handles a specific drop in any given context (NPC, bag, etc.). Has several
    /// different components that allows for customization, including dropCount and the canDrop delegate.
    /// </summary>
    public struct ItemDrop {

        /// <summary>
        /// Item ID of the dropped item.
        /// </summary>
        public int dropID;

        /// <summary>
        /// How many of the item specified will drop. If you wish to have a given range for the
        /// amount of the item that can be dropped, the first value of this Tuple is the minimum
        /// value (inclusive) and the second value of this Tuple is the maximum value (exclusive).
        /// If you just want a constant value of drops no matter what, set both values of the Tuple
        /// to the constant amount you want.
        /// </summary>
        public Tuple<int, int> dropCount;

        /// <summary>
        /// The method that is supposed to return whether or not this given item will drop, given
        /// whatever circumstances are present at the time of the item dropping. By default, this is
        /// a method that returns true no matter what.
        /// </summary>
        public CanDrop canDropMethod;

        /// <summary>
        /// Optional method that can do any specified action after the item that this ItemDrop
        /// instance creates is created. Useful for modifying the mod item data of a modded item, as
        /// an example.
        /// </summary>
        public PostItemCreation postItemCreationMethod;

        public ItemDrop(int itemID, Tuple<int, int> amount, CanDrop canDropDelegate = null, PostItemCreation postItemCreationDelegate = null) {
            dropID = itemID;
            dropCount = amount;
            canDropMethod = canDropDelegate ?? (() => true);
            postItemCreationMethod = postItemCreationDelegate ?? delegate { };
        }

        public delegate bool CanDrop();

        public delegate void PostItemCreation(int itemIndex);
    }
}