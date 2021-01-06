using System.Collections.Generic;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes {

    public abstract class BagChange {

        /// <summary>
        /// The ID of the bag to be changed.
        /// </summary>
        public virtual int AppliedBagID => -1;

        /// <summary>
        /// The "context" of the bag. Context will either be "present", "bossBag", "crate",
        /// "lockBox", "herbBag", or "goodieBag", depending on what type of bag the given item is.
        /// </summary>
        public virtual string BagContext => "";

        /// <summary>
        /// List of new drops this bag can potentially drop.
        /// </summary>
        public virtual List<ItemDrop> BagDrops => new List<ItemDrop>();
    }
}