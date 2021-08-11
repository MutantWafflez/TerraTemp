using System.Collections.Generic;
using Terraria;
using Terraria.ID;

using TerraTemp.Custom;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class GladiatorHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.GladiatorHelmet
        };

        public override float GetHeatComfortabilityChange(Player player) => 1f;
    }

    public class GladiatorChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.GladiatorBreastplate
        };

        public override float GetHeatComfortabilityChange(Player player) => 2f;
    }

    public class GladiatorLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.GladiatorLeggings
        };

        public override float GetHeatComfortabilityChange(Player player) => 1f;
    }

    public class GladiatorArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.GladiatorHelmet
        };

        public override int ChestPieceID => ItemID.GladiatorBreastplate;

        public override int LegPieceID => ItemID.GladiatorLeggings;

        public override void AdditionalSetBonusEffect(Player player) {
            if (player.statLife < player.statLifeMax2) {
                player.GetTempPlayer().temperatureChangeResist += 0.34f * (1f - ((float)player.statLife / (float)player.statLifeMax2));
            }
        }
    }
}