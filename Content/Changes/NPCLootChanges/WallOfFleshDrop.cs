using System.Collections.Generic;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Content.Items.Accessories;

namespace TerraTemp.Content.Changes.NPCLootChanges {

    public class WallOfFleshDrop : NPCLootChange {
        public override int AppliedNPCID => NPCID.WallofFlesh;

        public override List<IItemDropRule> ItemsToDrop => new List<IItemDropRule>() {
            new CommonDropNotScalingWithLuck(ModContent.ItemType<RiskBadge>(), 1, 1, 1)
        };
    }
}