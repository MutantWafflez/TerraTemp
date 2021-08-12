using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class StardustHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.StardustHelmet
        };

        public override float GetHeatComfortabilityChange(Player player) => 1.5f;

        public override float GetColdComfortabilityChange(Player player) => -1.5f;
    }

    public class StardustChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.StardustBreastplate
        };

        public override float GetHeatComfortabilityChange(Player player) => 1.5f;

        public override float GetColdComfortabilityChange(Player player) => -1.5f;
    }

    public class StardustLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.StardustLeggings
        };

        public override float GetHeatComfortabilityChange(Player player) => 1.5f;

        public override float GetColdComfortabilityChange(Player player) => -1.5f;
    }

    public class StardustArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.StardustHelmet
        };

        public override int ChestPieceID => ItemID.StardustBreastplate;

        public override int LegPieceID => ItemID.StardustLeggings;

        public override void AdditionalSetBonusEffect(Player player) {
            if (!Main.dayTime) {
                player.GetTempPlayer().baseDesiredTemperature += 8f;
            }
        }
    }
}