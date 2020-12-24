using Terraria;
using Terraria.ModLoader;

namespace TerraTemp.Content.Buffs.TempEffects {
    //TODO: Add custom shivering buff sprite
    public class Shivering : ModBuff {

        public override void SetDefaults() {
            DisplayName.SetDefault("Shivering");
            Description.SetDefault("The cold air nips at your skin");
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex) {
            player.statLifeMax2 = (int)(player.statLifeMax2 * 0.9f);
            player.statDefense = (int)(player.statDefense * 0.9f);
            player.moveSpeed *= 0.85f;
        }

    }
}
