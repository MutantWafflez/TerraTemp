using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Common.Players;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class SpiderHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SpiderMask
        };

        public override float HeatComfortabilityChange => 2f;

        public override float ColdComfortabilityChange => 1f;
    }

    public class SpiderChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SpiderBreastplate
        };

        public override float HeatComfortabilityChange => 2f;

        public override float ColdComfortabilityChange => 2f;
    }

    public class SpiderLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SpiderGreaves
        };

        public override float HeatComfortabilityChange => 2f;

        public override float ColdComfortabilityChange => 1f;
    }

    public class SpiderArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.SpiderMask
        };

        public override int ChestPieceID => ItemID.SpiderBreastplate;

        public override int LegPieceID => ItemID.SpiderGreaves;

        public override void AdditionalSetBonusEffect(Player player) {
            player.GetModPlayer<SetBonusPlayer>().spiderSetBonus = true;
        }
    }
}