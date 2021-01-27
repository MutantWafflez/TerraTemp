using Terraria;
using Terraria.ModLoader;
using TerraTemp.Content.Changes;
using TerraTemp.Custom.Structs;

namespace TerraTemp.Common.GlobalNPCs {

    /// <summary>
    /// Global NPC that is specific to handling any new drops of NPCs.
    /// </summary>
    public class VanillaNPCLootChanges : GlobalNPC {

        public override void NPCLoot(NPC npc) {
            foreach (NPCLootChange lootChange in TerraTemp.lootChanges) {
                if (npc.type == lootChange.AppliedNPCID) {
                    foreach (ItemDrop drop in lootChange.ItemsToDrop) {
                        if (drop.canDropMethod()) {
                            int dropCount = drop.dropCount.Item1 == drop.dropCount.Item2 ? drop.dropCount.Item1 : Main.rand.Next(drop.dropCount.Item1, drop.dropCount.Item2);

                            Item.NewItem(npc.getRect(), drop.dropID, dropCount);
                        }
                    }
                }
            }
        }
    }
}