using Terraria;
using Terraria.ModLoader;

namespace TerraTemp.Content.Buffs.TempEffects {

    public class Hypothermia : ModBuff {

        public override void SetDefaults() {
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex) {
            player.statLifeMax2 = (int)(player.statLifeMax2 * 0.75f);
            player.statDefense = (int)(player.statDefense * 0.67f);
            player.allDamageMult -= 0.25f;
            player.meleeSpeed *= 0.75f;
            player.moveSpeed *= 0.75f;
            player.chilled = true;
        }
    }
}