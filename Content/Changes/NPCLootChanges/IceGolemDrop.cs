using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Content.Items.Tomes;
using TerraTemp.Custom.Structs;

namespace TerraTemp.Content.Changes.NPCLootChanges {

    public class IceGolemDrop : NPCLootChange {
        public override int AppliedNPCID => NPCID.IceGolem;

        public override List<ItemDrop> ItemsToDrop => new List<ItemDrop>() {
            new ItemDrop(ModContent.ItemType<FrostTome>(), new Tuple<int, int>(1, 1), () => Main.rand.Next(0, 9) == 0, delegate(int itemIndex) {
                ((FrostTome)Main.item[itemIndex].modItem).tomeLevel = 2;
            })
        };
    }
}