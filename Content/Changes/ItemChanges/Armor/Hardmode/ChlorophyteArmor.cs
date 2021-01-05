using Terraria.ID;
using System.Collections.Generic;
using Terraria;
using TerraTemp.Utilities;
using System.Linq;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class ChlorophyteHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.ChlorophyteHelmet,
            ItemID.ChlorophyteMask,
            ItemID.ChlorophyteHeadgear
        };

        public override float ColdComfortabilityChange => 1f;

        public override float HeatComfortabilityChange => -1f;
    }

    public class ChlorophyteChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.ChlorophytePlateMail
        };

        public override float ColdComfortabilityChange => 2f;

        public override float HeatComfortabilityChange => -2f;
    }

    public class ChlorophyteLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.ChlorophyteGreaves
        };

        public override float ColdComfortabilityChange => 1f;

        public override float HeatComfortabilityChange => -1f;
    }

    public class ChlorophyteArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.ChlorophyteHelmet,
            ItemID.ChlorophyteMask,
            ItemID.ChlorophyteHeadgear
        };

        public override int ChestPieceID => ItemID.ChlorophytePlateMail;

        public override int LegPieceID => ItemID.ChlorophyteGreaves;

        public override void AdditionalSetBonusEffect(Player player) {
            List<int> listofCrits = new List<int>() {
                player.magicCrit,
                player.meleeCrit,
                player.rangedCrit,
                player.thrownCrit
            };
            player.GetTempPlayer().temperatureChangeResist += (float)listofCrits.Max() / 100f;
        }
    }
}