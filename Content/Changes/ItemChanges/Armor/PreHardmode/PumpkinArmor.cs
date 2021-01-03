using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class PumpkinHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.PumpkinHelmet
        };

        public override float HeatComfortabilityChange => 0.75f;

        public override float ColdComfortabilityChange => -0.75f;
    }

    public class PumpkinChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.PumpkinBreastplate
        };

        public override float HeatComfortabilityChange => 1.5f;

        public override float ColdComfortabilityChange => -1.5f;
    }

    public class PumpkinLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.PumpkinLeggings
        };

        public override float HeatComfortabilityChange => 0.75f;

        public override float ColdComfortabilityChange => -0.75f;
    }

    public class PumpkinArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.PumpkinHelmet
        };

        public override int ChestPieceID => ItemID.PumpkinBreastplate;

        public override int LegPieceID => ItemID.PumpkinLeggings;

        public override void AdditionalSetBonusEffect(Player player) {
            if (player.HasBuff(BuffID.WellFed)) {
                player.GetTempPlayer().comfortableLow -= 5f;
            }
        }
    }
}