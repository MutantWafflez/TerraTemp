using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using TerraTemp.Common.Systems;
using TerraTemp.Content.Changes;

namespace TerraTemp.Common.GlobalNPCs {

    /// <summary>
    /// Global NPC that is specific to handling any new drops of NPCs.
    /// </summary>
    public class VanillaNPCLootChanges : GlobalNPC {

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
            foreach (NPCLootChange lootChange in ContentListSystem.lootChanges) {
                if (npc.type == lootChange.AppliedNPCID) {
                    foreach (IItemDropRule drop in lootChange.ItemsToDrop) {
                        npcLoot.Add(drop);
                    }
                }
            }
        }
    }
}