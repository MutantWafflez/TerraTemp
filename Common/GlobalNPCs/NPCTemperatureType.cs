using Terraria;
using Terraria.ModLoader;
using TerraTemp.Custom;

namespace TerraTemp.Common.GlobalNPCs {

    /// <summary>
    /// Global NPC that deals with what "type" of temperature a given NPC is. This is used for when
    /// players are attacked by NPCs; if the NPC is considered a "hot" NPC, it will cause the
    /// player's temperature to decrease, and vice versa for cold NPCs.
    /// </summary>
    public class NPCTemperatureType : GlobalNPC {
        public bool isWarmNPC;
        public bool isColdNPC;

        public override bool InstancePerEntity => true;

        public override void SetDefaults(NPC npc) {
            isColdNPC = npc.coldDamage;
            isWarmNPC = TerraTemp.warmNPCTypes.Contains(npc.type);
        }

        public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit) {
            if (isWarmNPC) {
                target.GetTempPlayer().currentTemperature += 3f;
            }

            if (isColdNPC) {
                target.GetTempPlayer().currentTemperature -= 3f;
            }
        }
    }
}