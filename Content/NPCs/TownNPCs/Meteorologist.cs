using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace TerraTemp.Content.NPCs.TownNPCs {

    [AutoloadHead]
    public class Meteorologist : ModNPC {

        public override void SetStaticDefaults() {
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }

        public override void SetDefaults() {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money) => NPC.downedSlimeKing && Main.raining;

        public override string TownNPCName() {
            List<string> nameList = new List<string>() {
                "Aimé",
                "Diodore",
                "Nathanaël",
                "Arnaud",
                "Guillaume",
                "Justin",
                "Loan",
                "Gilbert",
                "Loup",
                "Florian",
                "Bernard",
                "Philippe",
                "Dany",
                "Corin",
                "Rosaire",
                "Bertrand",
                "Mathieu"
            };
            return nameList[WorldGen.genRand.Next(0, nameList.Count)];
        }

        public override string GetChat() {
            return base.GetChat();
        }
    }
}