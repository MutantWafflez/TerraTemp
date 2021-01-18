using Terraria;
using Terraria.ModLoader;
using TerraTemp.Content.Items.Materials.Fish;

namespace TerraTemp.Common.Players {

    /// <summary>
    /// Mod Player that exclusively handles catching of TerraTemp modded fish.
    /// </summary>
    public class FishingPlayer : ModPlayer {

        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk) {
            if (junk) {
                return;
            }
            //Barb Fish (25% chance per catch on the Jungle Surface in Water/Honey)
            if (player.ZoneJungle && worldLayer == 1 && liquidType != 1 && Main.rand.Next(7) == 0) {
                caughtType = ModContent.ItemType<BarbFish>();
                return;
            }
        }
    }
}