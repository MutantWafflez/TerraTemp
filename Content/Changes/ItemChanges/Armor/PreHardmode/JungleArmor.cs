using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Content.Changes.Climates;
using TerraTemp.Custom;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class JungleHat : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int> {
            ItemID.JungleHat,
            ItemID.AncientCobaltHelmet
        };

        public override float GetHeatComfortabilityChange(Player player) => 1f;
    }

    public class JungleShirt : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int> {
            ItemID.JungleShirt,
            ItemID.AncientCobaltBreastplate
        };

        public override float GetHeatComfortabilityChange(Player player) => 3f;
    }

    public class JunglePants : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int> {
            ItemID.JunglePants,
            ItemID.AncientCobaltLeggings
        };

        public override float GetHeatComfortabilityChange(Player player) => 1f;
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
                player.GetTempPlayer().relativeHumidity -= jungleClimateHumidity.GetHumidityChange(player);
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
                player.GetTempPlayer().relativeHumidity -= jungleClimateHumidity.GetHumidityChange(player);
            }
        }
    }
}