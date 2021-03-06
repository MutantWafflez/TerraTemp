﻿using System.Collections.Generic;
using Terraria;
using Terraria.ID;

using TerraTemp.Common.Players;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class FrostHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.FrostHelmet
        };

        public override float GetColdComfortabilityChange(Player player) => -4f;

        public override float GetHeatComfortabilityChange(Player player) => -2f;
    }

    public class FrostChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.FrostBreastplate
        };

        public override float GetColdComfortabilityChange(Player player) => -4f;

        public override float GetHeatComfortabilityChange(Player player) => -2f;
    }

    public class FrostLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.FrostLeggings
        };

        public override float GetColdComfortabilityChange(Player player) => -4f;

        public override float GetHeatComfortabilityChange(Player player) => -2f;
    }

    public class FrostArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.FrostHelmet
        };

        public override int ChestPieceID => ItemID.FrostBreastplate;

        public override int LegPieceID => ItemID.FrostLeggings;

        public override void AdditionalSetBonusEffect(Player player) {
            player.GetModPlayer<AccessoryPlayer>().frostRune = true;
        }
    }
}