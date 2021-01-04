using Terraria.ID;
using System.Collections.Generic;
using Terraria;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class VortexHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.VortexHelmet
        };

        public override float ColdComfortabilityChange => 2f;

        public override float HeatComfortabilityChange => -2f;
    }

    public class VortexChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.VortexBreastplate
        };

        public override float ColdComfortabilityChange => 3f;

        public override float HeatComfortabilityChange => -3f;
    }

    public class VortexLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.VortexLeggings
        };

        public override float ColdComfortabilityChange => 2f;

        public override float HeatComfortabilityChange => -2f;
    }

    public class VortexArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.VortexHelmet
        };

        public override int ChestPieceID => ItemID.VortexBreastplate;

        public override int LegPieceID => ItemID.VortexLeggings;

        public override void AdditionalSetBonusEffect(Player player) {
            player.GetTempPlayer().temperatureChangeResist += 0.95f * (1f - player.stealth);
        }
    }
}