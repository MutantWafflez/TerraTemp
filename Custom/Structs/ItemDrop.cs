﻿using System;

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

        public ItemDrop(int itemID, Tuple<int, int> amount, CanDrop canDropDelegate = null) {
            dropID = itemID;
            dropCount = amount;
            if (canDropDelegate == null) {
                canDropMethod = delegate () {
                    return true;
                };
            }
            else {
                canDropMethod = canDropDelegate;
            }
        }

        public delegate bool CanDrop();
    }
}