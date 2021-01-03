using Terraria.ID;
using System.Collections.Generic;
using Terraria;
using TerraTemp.Content.Changes.TempBiomes;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class FossilHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.FossilHelm
        };

        public override float DesiredTemperatureChange => 2f;
    }

    public class FossilChesplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.FossilShirt
        };

        public override float DesiredTemperatureChange => 2f;
    }

    public class FossilLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.FossilPants
        };

        public override float DesiredTemperatureChange => 2f;
    }

    public class FossilArmor : SetBonusChange {
        private readonly DesertClimate desertClimate = new DesertClimate();

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.FossilHelm
        };

        public override int ChestPieceID => ItemID.FossilShirt;

        public override int LegPieceID => ItemID.FossilPants;

        public override void AdditionalSetBonusEffect(Player player) {
            if (player.ZoneDesert) {
                player.GetTempPlayer().baseDesiredTemperature -= desertClimate.TemperatureModification;
            }
        }
    }
}