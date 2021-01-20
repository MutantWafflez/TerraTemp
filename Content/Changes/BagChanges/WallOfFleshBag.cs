using System;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Content.Items.Accessories;
using TerraTemp.Custom.Structs;

namespace TerraTemp.Content.Changes.BagChanges {

    public class WallOfFleshBag : BagChange {
        public override int AppliedBagID => ItemID.WallOfFleshBossBag;

        public override string BagContext => "bossBag";

        public override List<ItemDrop> BagDrops => new List<ItemDrop>() {
            new ItemDrop(ModContent.ItemType<RiskBadge>(), new Tuple<int, int>(1, 1))
        };
    }
}