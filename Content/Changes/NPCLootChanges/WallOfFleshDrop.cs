using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Content.Items.Accessories;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes.NPCLootChanges {

    public class WallOfFleshDrop : NPCLootChange {
        public override int AppliedNPCID => NPCID.WallofFlesh;

        public override List<ItemDrop> ItemsToDrop => new List<ItemDrop>() {
            new ItemDrop(ModContent.ItemType<RiskBadge>(), new Tuple<int, int>(1, 1), delegate {
                return !Main.expertMode;
            })
        };
    }
}