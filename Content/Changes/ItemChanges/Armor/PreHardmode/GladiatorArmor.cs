using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class GladiatorHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.GladiatorHelmet
        };

        public override float HeatComfortabilityChange => 1f;
    }

    public class GladiatorChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.GladiatorBreastplate
        };

        public override float HeatComfortabilityChange => 2f;
    }

    public class GladiatorLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.GladiatorLeggings
        };

        public override float HeatComfortabilityChange => 1f;
    }

    public class GladiatorArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
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