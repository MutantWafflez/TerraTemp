﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraTemp.Content.Buffs.TempEffects {
    public class HeatStroke : ModBuff {
        public override void SetStaticDefaults() {
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            player.statLifeMax2 = (int)(player.statLifeMax2 * 0.75f);
            player.statDefense = (int)(player.statDefense * 0.67f);
            player.GetDamage(DamageClass.Generic) -= 0.25f;
            player.GetAttackSpeed(DamageClass.Melee) *= 0.75f;
            player.moveSpeed *= 0.75f;
            player.chilled = true;
        }
    }
}