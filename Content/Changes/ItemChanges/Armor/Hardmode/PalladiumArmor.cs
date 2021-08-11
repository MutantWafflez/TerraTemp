using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Common.Players;
using TerraTemp.Custom;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class PalladiumHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.PalladiumHelmet,
            ItemID.PalladiumHeadgear,
            ItemID.PalladiumMask
        };

        public override float GetHeatComfortabilityChange(Player player) => -2f;

        public override float GetColdComfortabilityChange(Player player) => 2f;
    }

    public class PalladiumChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.PalladiumBreastplate
        };

        public override float GetHeatComfortabilityChange(Player player) => -2f;

        public override float GetColdComfortabilityChange(Player player) => 2f;
    }

    public class PalladiumLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.PalladiumLeggings
        };

        public override float GetHeatComfortabilityChange(Player player) => -2f;

        public override float GetColdComfortabilityChange(Player player) => 2f;
    }

    public class PalladiumArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
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