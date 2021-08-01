using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Common.Players;
using TerraTemp.Custom;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class CobaltHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.CobaltHelmet,
            ItemID.CobaltMask,
            ItemID.CobaltHat
        };

        public override float GetCriticalTemperatureChange(Player player) => 1.5f;

        public override float GetColdComfortabilityChange(Player player) => 2f;
    }

    public class CobaltChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.CobaltBreastplate
        };

        public override float GetCriticalTemperatureChange(Player player) => 1.5f;

        public override float GetColdComfortabilityChange(Player player) => 2f;
    }

    public class CobaltLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.CobaltLeggings
        };

        public override float GetCriticalTemperatureChange(Player player) => 1f;

        public override float GetColdComfortabilityChange(Player player) => 2f;
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
                player.GetDamage(DamageClass.Generic) += 0.03f * (tempPlayer.currentTemperature - tempPlayer.comfortableHigh);
            }
        }
    }
}