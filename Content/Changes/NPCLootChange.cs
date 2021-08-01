using System;
using System.Collections.Generic;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using TerraTemp.Common.Systems;

namespace TerraTemp.Content.Changes {

    public abstract class NPCLootChange : ILoadable {

        /// <summary>
        /// The ID of the NPC that will drop the given item(s).
        /// </summary>
        public virtual int AppliedNPCID => -1;

        public virtual List<IItemDropRule> ItemsToDrop => new List<IItemDropRule>();

        public void Load(Mod mod) {
            ContentListSystem.lootChanges.Add((NPCLootChange)Activator.CreateInstance(GetType()));
        }

        public void Unload() { }
    }
}