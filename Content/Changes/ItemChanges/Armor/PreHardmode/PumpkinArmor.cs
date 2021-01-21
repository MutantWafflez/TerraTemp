using System.Collections.Generic;
using Terraria;
using Terraria.ID;

using TerraTemp.Custom;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class PumpkinHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.PumpkinHelmet
        };

        public override float GetHeatComfortabilityChange(Player player) => 0.75f;

        public override float GetColdComfortabilityChange(Player player) => -0.75f;
    }

    public class PumpkinChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.PumpkinBreastplate
        };

        public override float GetHeatComfortabilityChange(Player player) => 1.5f;

        public override float GetColdComfortabilityChange(Player player) => -1.5f;
    }

    public class PumpkinLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.PumpkinLeggings
        };

        public override float GetHeatComfortabilityChange(Player player) => 0.75f;

        public override float GetColdComfortabilityChange(Player player) => -0.75f;
    }

    public class PumpkinArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
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