using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraTemp.Content.Buffs.TempEffects {
    public class Sweaty : ModBuff {
        public override void SetStaticDefaults() {
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            player.lifeRegen = 0;
            player.statDefense = (int)(player.statDefense * 0.9f);
            player.moveSpeed *= 0.85f;
        }
    }
}