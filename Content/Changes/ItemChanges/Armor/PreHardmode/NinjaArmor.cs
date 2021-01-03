using Terraria.ID;
using System.Collections.Generic;
using Terraria;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class NinjaHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.NinjaHood
        };

        public override float ColdComfortabilityChange => -1f;
    }

    public class NinjaChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.NinjaShirt
        };

        public override float ColdComfortabilityChange => -1f;
    }

    public class NinjaLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.NinjaPants
        };

        public override float ColdComfortabilityChange => -1f;
    }

    public class NinjaArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.NinjaHood
        };

        public override int ChestPieceID => ItemID.NinjaShirt;

        public override int LegPieceID => ItemID.NinjaPants;

        public override void AdditionalSetBonusEffect(Player player) {
            if (!Main.dayTime) {
                player.GetTempPlayer().temperatureChangeResist += 0.25f;
            }
        }
    }
}