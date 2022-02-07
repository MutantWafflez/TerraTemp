using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using TerraTemp.Content.Items.Materials.Fish;

namespace TerraTemp.Common.Players {
    /// <summary>
    /// Mod Player that exclusively handles catching of TerraTemp modded fish.
    /// </summary>
    public class FishingPlayer : ModPlayer {
        public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition) {
            if (Player.ZoneJungle && !attempt.inLava && attempt.heightLevel == 1 && attempt.uncommon && Main.rand.Next(3) == 0) {
                itemDrop = ModContent.ItemType<BarbFish>();
            }
        }
    }
}