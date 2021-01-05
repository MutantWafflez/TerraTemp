using Terraria.ID;
using System.Collections.Generic;
using Terraria.GameContent.Events;
using Terraria;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class HuntressHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.HuntressWig
        };

        public override float TemperatureResistanceChange => -0.075f;
    }

    public class HuntressChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.HuntressJerkin
        };

        public override float TemperatureResistanceChange => -0.075f;
    }

    public class HuntressLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.HuntressPants
        };

        public override float TemperatureResistanceChange => -0.075f;
    }

    public class HuntressArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.HuntressWig
        };

        public override int ChestPieceID => ItemID.HuntressJerkin;

        public override int LegPieceID => ItemID.HuntressPants;

        public override void AdditionalSetBonusEffect(Player player) {
            if (DD2Event.Ongoing) {
                player.GetTempPlayer().temperatureChangeResist += 0.67f;
            }
        }
    }
}