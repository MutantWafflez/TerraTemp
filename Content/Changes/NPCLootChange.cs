using System.Collections.Generic;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes {

    public abstract class NPCLootChange {

        /// <summary>
        /// The ID of the NPC that will drop the given item(s).
        /// </summary>
        public virtual int AppliedNPCID => -1;

        public virtual List<NPCDrop> ItemsToDrop => new List<NPCDrop>();
    }
}