using Terraria;
using Terraria.ModLoader;
using TerraTemp.Content.Changes;
using TerraTemp.Custom.Structs;

namespace TerraTemp.Common.GlobalItems {

    /// <summary>
    /// GlobalItem that handles all of the Bag Changes within this mod.
    /// </summary>
    public class VanillaBagChanges : GlobalItem {

        public override void OpenVanillaBag(string context, Player player, int arg) {
            foreach (BagChange bagChange in TerraTemp.bagChanges) {
                if (context == bagChange.BagContext && arg == bagChange.AppliedBagID) {
                    foreach (ItemDrop drop in bagChange.BagDrops) {
                        if (drop.canDropMethod()) {
                            int dropCount = drop.dropCount.Item1 == drop.dropCount.Item2 ? drop.dropCount.Item1 : Main.rand.Next(drop.dropCount.Item1, drop.dropCount.Item2);

                            player.QuickSpawnItem(drop.dropID, dropCount);
                        }
                    }
                }
            }
        }
    }
}