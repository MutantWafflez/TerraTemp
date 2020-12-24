using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace TerraTemp.Content.Buffs.TempEffects {
    public class Sweaty : ModBuff {

        public override void SetDefaults() {
            DisplayName.SetDefault("Sweaty");
            Description.SetDefault("The heat drenches your clothing");
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex) {
            player.dripping = true;
            player.statLifeMax2 = (int)(player.statLifeMax2 * 0.9f);
            player.statDefense = (int)(player.statDefense * 0.9f);
            player.moveSpeed *= 0.85f;
        }

    }
}
