using Terraria;
using Terraria.ModLoader;

namespace TerraTemp.Content.Buffs.TempEffects {
    public class HeatStroke : ModBuff {

        public override void SetDefaults() {
            DisplayName.SetDefault("Heat Stroke");
            Description.SetDefault("Heat consumes your every nerve, the end is near");
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex) {
            player.statLifeMax2 = (int)(player.statLifeMax2 * 0.67f);
            player.statDefense = (int)(player.statDefense * 0.67f);
            player.meleeSpeed *= 0.75f;
            player.moveSpeed *= 0.75f;
            player.chilled = true;
            player.blackout = true;
        }

    }
}
