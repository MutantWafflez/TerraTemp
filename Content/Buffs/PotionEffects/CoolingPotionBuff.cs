using Terraria;
using Terraria.ModLoader;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Buffs.PotionEffects {

    public class CoolingPotionBuff : ModBuff {

        public override void SetDefaults() {
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            player.GetTempPlayer().comfortableHigh += 8f;
        }
    }
}