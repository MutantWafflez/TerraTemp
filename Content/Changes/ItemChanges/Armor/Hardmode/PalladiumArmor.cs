using Terraria.ID;
using System.Collections.Generic;
using Terraria;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class PalladiumHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.PalladiumHelmet,
            ItemID.PalladiumHeadgear,
            ItemID.PalladiumMask
        };

        public override float HeatComfortabilityChange => -2f;

        public override float ColdComfortabilityChange => 2f;
    }

    public class PalladiumChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.PalladiumBreastplate
        };

        public override float HeatComfortabilityChange => -2f;

        public override float ColdComfortabilityChange => 2f;
    }

    public class PalladiumLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.PalladiumLeggings
        };

        public override float HeatComfortabilityChange => -2f;

        public override float ColdComfortabilityChange => 2f;
    }

    public class PalladiumArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.PalladiumHelmet,
            ItemID.PalladiumHeadgear,
            ItemID.PalladiumMask
        };

        public override int ChestPieceID => ItemID.PalladiumBreastplate;

        public override int LegPieceID => ItemID.PalladiumLeggings;

        public override void AdditionalSetBonusEffect(Player player) {
            if (player.HasBuff(BuffID.RapidHealing)) {
                TempPlayer tempPlayer = player.GetTempPlayer();
                tempPlayer.comfortableLow -= 12f;
                tempPlayer.comfortableHigh += 12f;
            }
        }
    }
}