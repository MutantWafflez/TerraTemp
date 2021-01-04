using Terraria.ID;
using System.Collections.Generic;
using Terraria;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class StardustHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.StardustHelmet
        };

        public override float HeatComfortabilityChange => 1.5f;

        public override float ColdComfortabilityChange => -1.5f;
    }

    public class StardustChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.StardustBreastplate
        };

        public override float HeatComfortabilityChange => 1.5f;

        public override float ColdComfortabilityChange => -1.5f;
    }

    public class StardustLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.StardustLeggings
        };

        public override float HeatComfortabilityChange => 1.5f;

        public override float ColdComfortabilityChange => -1.5f;
    }

    public class StardustArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
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