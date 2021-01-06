using Terraria;
using Terraria.ModLoader;

namespace TerraTemp.Content.Buffs.TempEffects {

    public class Sweaty : ModBuff {

        public override void SetDefaults() {
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex) {
            player.lifeRegen = 0;
            player.statDefense = (int)(player.statDefense * 0.9f);
            player.moveSpeed *= 0.85f;
        }
    }
}