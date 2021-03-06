﻿using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Content.Changes.Climates;
using TerraTemp.Custom;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class CactusHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.CactusHelmet
        };

        public override float GetDesiredTemperatureChange(Player player) => 0.5f;
    }

    public class CactusChesplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.CactusBreastplate
        };

        public override float GetDesiredTemperatureChange(Player player) => 0.75f;
    }

    public class CactusLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.CactusLeggings
        };

        public override float GetDesiredTemperatureChange(Player player) => 0.25f;
    }

    public class CactusArmor : SetBonusChange {
        private readonly DesertClimate desertClimate = new DesertClimate();

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.CactusHelmet
        };

        public override int ChestPieceID => ItemID.CactusBreastplate;

        public override int LegPieceID => ItemID.CactusLeggings;

        public override void AdditionalSetBonusEffect(Player player) {
            if (player.ZoneDesert) {
                player.GetTempPlayer().baseDesiredTemperature -= desertClimate.GetDesiredTemperatureChange(player) / 4f;
            }
        }
    }
}