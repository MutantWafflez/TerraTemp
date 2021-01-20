﻿using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Content.Changes.TempBiomes;
using TerraTemp.Custom;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class JungleHat : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int> {
            ItemID.JungleHat,
            ItemID.AncientCobaltHelmet
        };

        public override float HeatComfortabilityChange => 1f;
    }

    public class JungleShirt : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int> {
            ItemID.JungleShirt,
            ItemID.AncientCobaltBreastplate
        };

        public override float HeatComfortabilityChange => 3f;
    }

    public class JunglePants : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int> {
            ItemID.JunglePants,
            ItemID.AncientCobaltLeggings
        };

        public override float HeatComfortabilityChange => 1f;
    }

    public class JungleArmor : SetBonusChange {
        private readonly JungleClimate jungleClimateHumidity = new JungleClimate();

        public override HashSet<int> HelmetPieceID => new HashSet<int> {
            ItemID.JungleHat
        };

        public override int ChestPieceID => ItemID.JungleShirt;

        public override int LegPieceID => ItemID.JunglePants;

        public override void AdditionalSetBonusEffect(Player player) {
            if (player.ZoneJungle) {
                player.GetTempPlayer().relativeHumidity -= jungleClimateHumidity.HumidityModification;
            }
        }
    }

    public class AncientCobaltArmor : SetBonusChange {
        private readonly JungleClimate jungleClimateHumidity = new JungleClimate();

        public override HashSet<int> HelmetPieceID => new HashSet<int> {
            ItemID.AncientCobaltHelmet
        };

        public override int ChestPieceID => ItemID.AncientCobaltBreastplate;

        public override int LegPieceID => ItemID.AncientCobaltLeggings;

        public override void AdditionalSetBonusEffect(Player player) {
            if (player.ZoneJungle) {
                player.GetTempPlayer().relativeHumidity -= jungleClimateHumidity.HumidityModification;
            }
        }
    }
}