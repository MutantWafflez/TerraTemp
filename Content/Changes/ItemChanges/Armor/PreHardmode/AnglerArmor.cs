using Terraria.ID;
using System.Collections.Generic;
using Terraria;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class AnglerHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.AnglerHat
        };

        public override float HeatComfortabilityChange => 1f;
    }

    public class AnglerChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.AnglerVest
        };

        public override float HeatComfortabilityChange => 2f;
    }

    public class AnglerLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.AnglerPants
        };

        public override float HeatComfortabilityChange => 1f;
    }

    public class AnglerArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.AnglerHat
        };

        public override int ChestPieceID => ItemID.AnglerVest;

        public override int LegPieceID => ItemID.AnglerPants;

        public override void AdditionalSetBonusEffect(Player player) {
            player.GetTempPlayer().temperatureChangeResist += ((float)player.FishingLevel() / 100f) * 0.34f;
        }
    }
}