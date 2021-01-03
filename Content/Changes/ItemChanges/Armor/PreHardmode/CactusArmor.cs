using Terraria.ID;
using System.Collections.Generic;
using TerraTemp.Content.Changes.TempBiomes;
using Terraria;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class CactusHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.CactusHelmet
        };

        public override float DesiredTemperatureChange => 1f;
    }

    public class CactusChesplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.CactusBreastplate
        };

        public override float DesiredTemperatureChange => 2f;
    }

    public class CactusLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.CactusLeggings
        };

        public override float DesiredTemperatureChange => 1f;
    }

    public class CactusArmor : SetBonusChange {
        private readonly DesertClimate desertClimate = new DesertClimate();

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.CactusHelmet
        };

        public override int ChestPieceID => ItemID.CactusBreastplate;

        public override int LegPieceID => ItemID.CactusLeggings;

        public override void AdditionalSetBonusEffect(Player player) {
            if (player.ZoneDesert) {
                player.GetTempPlayer().baseDesiredTemperature -= desertClimate.TemperatureModification / 4f;
            }
        }
    }
}