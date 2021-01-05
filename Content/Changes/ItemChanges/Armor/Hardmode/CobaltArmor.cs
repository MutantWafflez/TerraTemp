using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class CobaltHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.CobaltHelmet,
            ItemID.CobaltMask,
            ItemID.CobaltHat
        };

        public override float CriticalTemperatureChange => 1.5f;

        public override float ColdComfortabilityChange => 2f;
    }

    public class CobaltChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.CobaltBreastplate
        };

        public override float CriticalTemperatureChange => 1.5f;

        public override float ColdComfortabilityChange => 2f;
    }

    public class CobaltLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.CobaltLeggings
        };

        public override float CriticalTemperatureChange => 1f;

        public override float ColdComfortabilityChange => 2f;
    }

    public class CobaltArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.CobaltHelmet,
            ItemID.CobaltMask,
            ItemID.CobaltHat
        };

        public override int ChestPieceID => ItemID.CobaltBreastplate;

        public override int LegPieceID => ItemID.CobaltLeggings;

        public override void AdditionalSetBonusEffect(Player player) {
            TempPlayer tempPlayer = player.GetTempPlayer();
            if (tempPlayer.currentTemperature > tempPlayer.comfortableHigh) {
                player.allDamageMult += 0.03f * (tempPlayer.currentTemperature - tempPlayer.comfortableHigh);
            }
        }
    }
}