using Terraria;
using Terraria.ModLoader;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Buffs.MiscEffects {

    public class TempResistBuff : ModBuff {

        public override void SetDefaults() {
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            player.GetTempPlayer().temperatureChangeResist += 0.4f;
        }
    }
}