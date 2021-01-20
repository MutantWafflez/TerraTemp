using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Custom;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class StardustHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.StardustHelmet
        };

        public override float HeatComfortabilityChange => 1.5f;

        public override float ColdComfortabilityChange => -1.5f;
    }

    public class StardustChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.StardustBreastplate
        };

        public override float HeatComfortabilityChange => 1.5f;

        public override float ColdComfortabilityChange => -1.5f;
    }

    public class StardustLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.StardustLeggings
        };

        public override float HeatComfortabilityChange => 1.5f;

        public override float ColdComfortabilityChange => -1.5f;
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