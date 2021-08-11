using System.Collections.Generic;
using Terraria;
using Terraria.ID;

using Terraria.ModLoader;
using TerraTemp.Common.Players;
using TerraTemp.Content.Buffs.TempEffects;
using TerraTemp.Custom;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class SolarFlareHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SolarFlareHelmet
        };

        public override float GetColdComfortabilityChange(Player player) => 2f;
    }

    public class SolarFlareChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SolarFlareBreastplate
        };

        public override float GetColdComfortabilityChange(Player player) => 3f;
    }

    public class SolarFlareLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SolarFlareLeggings
        };

        public override float GetColdComfortabilityChange(Player player) => 2f;
    }

    public class SolarFlareArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.SolarFlareHelmet
        };

        public override int ChestPieceID => ItemID.SolarFlareBreastplate;

        public override int LegPieceID => ItemID.SolarFlareLeggings;

        public override void AdditionalSetBonusEffect(Player player) {
            TempPlayer tempPlayer = player.GetTempPlayer();
            if (tempPlayer.currentTemperature > tempPlayer.comfortableHigh) {
                player.lifeRegen = (int)(player.lifeRegen * (1f + (0.05f * (tempPlayer.currentTemperature - tempPlayer.comfortableHigh))));
                player.buffImmune[ModContent.BuffType<Sweaty>()] = true;
                player.buffImmune[ModContent.BuffType<HeatStroke>()] = true;
            }
        }
    }
}