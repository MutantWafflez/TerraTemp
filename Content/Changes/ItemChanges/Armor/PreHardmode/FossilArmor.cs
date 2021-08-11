using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Content.Changes.Climates;
using TerraTemp.Custom;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class FossilHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.FossilHelm
        };

        public override float GetDesiredTemperatureChange(Player player) => 2f;
    }

    public class FossilChesplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.FossilShirt
        };

        public override float GetDesiredTemperatureChange(Player player) => 2f;
    }

    public class FossilLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.FossilPants
        };

        public override float GetDesiredTemperatureChange(Player player) => 2f;
    }

    public class FossilArmor : SetBonusChange {
        private readonly DesertClimate desertClimate = new DesertClimate();

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.FossilHelm
        };

        public override int ChestPieceID => ItemID.FossilShirt;

        public override int LegPieceID => ItemID.FossilPants;

        public override void AdditionalSetBonusEffect(Player player) {
            if (player.ZoneDesert) {
                player.GetTempPlayer().baseDesiredTemperature -= desertClimate.GetDesiredTemperatureChange(player);
            }
        }
    }
}