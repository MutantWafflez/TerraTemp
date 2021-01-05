using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class ApprenticeHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ApprenticeHat
        };

        public override float TemperatureResistanceChange => -0.075f;
    }

    public class ApprenticeChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ApprenticeRobe
        };

        public override float TemperatureResistanceChange => -0.075f;
    }

    public class ApprenticeLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ApprenticeTrousers
        };

        public override float TemperatureResistanceChange => -0.075f;
    }

    public class ApprenticeArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.ApprenticeHat
        };

        public override int ChestPieceID => ItemID.ApprenticeRobe;

        public override int LegPieceID => ItemID.ApprenticeTrousers;

        public override void AdditionalSetBonusEffect(Player player) {
            if (DD2Event.Ongoing) {
                player.GetTempPlayer().temperatureChangeResist += 0.67f;
            }
        }
    }
}