using System.Collections.Generic;
using TerraTemp.Custom.Structs;

namespace TerraTemp.Content.Changes {

    public abstract class NPCLootChange {

        /// <summary>
        /// The ID of the NPC that will drop the given item(s).
        /// </summary>
        public virtual int AppliedNPCID => -1;

        public virtual List<ItemDrop> ItemsToDrop => new List<ItemDrop>();
    }
}