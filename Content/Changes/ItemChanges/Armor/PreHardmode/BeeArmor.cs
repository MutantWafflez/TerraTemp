using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Custom;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class BeeHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.BeeHeadgear
        };

        public override float ColdComfortabilityChange => 1f;

        public override float HeatComfortabilityChange => -1f;
    }

    public class BeeChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.BeeBreastplate
        };

        public override float ColdComfortabilityChange => 2f;

        public override float HeatComfortabilityChange => -2f;
    }

    public class BeeLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.BeeGreaves
        };

        public override float ColdComfortabilityChange => 1f;

        public override float HeatComfortabilityChange => -1f;
    }

    public class BeeArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.BeeHeadgear
        };

        public override int ChestPieceID => ItemID.BeeBreastplate;

        public override int LegPieceID => ItemID.BeeGreaves;

        public override void AdditionalSetBonusEffect(Player player) {
            if (player.HasBuff(BuffID.Honey)) {
                player.GetTempPlayer().temperatureChangeResist += 0.5f;
            }
        }
    }
}