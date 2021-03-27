using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Content.Items.Tomes;
using TerraTemp.Custom.Structs;

namespace TerraTemp.Content.Changes.NPCLootChanges {

    public class RedDevilDrop : NPCLootChange {
        public override int AppliedNPCID => NPCID.RedDevil;

        public override List<ItemDrop> ItemsToDrop => new List<ItemDrop>() {
            new ItemDrop(ModContent.ItemType<FlameTome>(), new Tuple<int, int>(1, 1), () => Main.rand.Next(0, 9) == 0, delegate(int itemIndex) {
                ((FlameTome)Main.item[itemIndex].modItem).tomeLevel = 2;
            })
        };
    }
}