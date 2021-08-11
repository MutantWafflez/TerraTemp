using System.Collections.Generic;
using Terraria;
using Terraria.ID;

using TerraTemp.Custom;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class NinjaHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.NinjaHood
        };

        public override float GetColdComfortabilityChange(Player player) => -1f;
    }

    public class NinjaChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.NinjaShirt
        };

        public override float GetColdComfortabilityChange(Player player) => -1f;
    }

    public class NinjaLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.NinjaPants
        };

        public override float GetColdComfortabilityChange(Player player) => -1f;
    }

    public class NinjaArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
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