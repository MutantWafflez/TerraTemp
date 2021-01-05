﻿using Terraria.ID;
using System.Collections.Generic;
using Terraria;
using TerraTemp.Utilities;
using System.Linq;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class ChlorophyteHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ChlorophyteHelmet,
            ItemID.ChlorophyteMask,
            ItemID.ChlorophyteHeadgear
        };

        public override float ColdComfortabilityChange => 1f;

        public override float HeatComfortabilityChange => -1f;
    }

    public class ChlorophyteChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ChlorophytePlateMail
        };

        public override float ColdComfortabilityChange => 2f;

        public override float HeatComfortabilityChange => -2f;
    }

    public class ChlorophyteLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ChlorophyteGreaves
        };

        public override float ColdComfortabilityChange => 1f;

        public override float HeatComfortabilityChange => -1f;
    }

    public class ChlorophyteArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.ChlorophyteHelmet,
            ItemID.ChlorophyteMask,
            ItemID.ChlorophyteHeadgear
        };

        public override int ChestPieceID => ItemID.ChlorophytePlateMail;

        public override int LegPieceID => ItemID.ChlorophyteGreaves;

        public override void AdditionalSetBonusEffect(Player player) {
            HashSet<int> listofCrits = new HashSet<int>() {
                player.magicCrit,
                player.meleeCrit,
                player.rangedCrit,
                player.thrownCrit
            };
            player.GetTempPlayer().temperatureChangeResist += (float)listofCrits.Max() / 100f;
        }
    }
}