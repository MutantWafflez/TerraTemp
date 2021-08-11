using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Content.Buffs.MiscEffects;
using TerraTemp.Custom;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Common.Players {

    /// <summary>
    /// ModPlayer that handles any potential Set Bonuses that require a Player hook.
    /// </summary>
    public class SetBonusPlayer : ModPlayer {

        //Set bonus bools
        public bool spiderSetBonus;

        public bool mythrilSetBonus;

        public override void ResetEffects() {
            spiderSetBonus = false;
        }

        public override void OnHitAnything(float x, float y, Entity victim) {
            TempPlayer tempPlayer = Player.GetTempPlayer();
            //Spider Set Bonus
            if (spiderSetBonus && tempPlayer.currentTemperature > tempPlayer.comfortableHigh) {
                if (victim is NPC npc) {
                    npc.AddBuff(BuffID.Venom, 60 * 5);
                }
                else if (victim is Player player) {
                    player.AddBuff(BuffID.Venom, 60 * 5);
                }
            }
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit) {
            //Mythril Set Bonus
            if (mythrilSetBonus) {
                Player.AddBuff(ModContent.BuffType<TempResistBuff>(), 60 * 5);
            }
        }
    }
}