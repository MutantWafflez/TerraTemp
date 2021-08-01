using Terraria;
using Terraria.ModLoader;
using TerraTemp.Content.Changes;
using TerraTemp.Custom.Structs;

namespace TerraTemp.Common.GlobalNPCs {

    /// <summary>
    /// Global NPC that is specific to handling any new drops of NPCs.
    /// </summary>
    public class VanillaNPCLootChanges : GlobalNPC {

        //TODO: Reimplement properly
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
            /*foreach (NPCLootChange lootChange in TerraTemp.lootChanges) {
                if (npc.type == lootChange.AppliedNPCID) {
                    foreach (ItemDrop drop in lootChange.ItemsToDrop) {
                        //Game Menu check is for mods such as Recipe Browser that call NPCLoot() when building the Loot Cache
                        if (drop.canDropMethod() && !Main.gameMenu) {
                            int dropCount = drop.dropCount.Item1 == drop.dropCount.Item2 ? drop.dropCount.Item1 : Main.rand.Next(drop.dropCount.Item1, drop.dropCount.Item2);

                            int itemIndex = Item.NewItem(npc.getRect(), drop.dropID, dropCount);
                            drop.postItemCreationMethod(itemIndex);
                        }
                    }
                }
            }*/
        }
    }
}