using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Content.Changes.TempBiomes;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class JungleHat : ItemChange {

        public override List<int> AppliedItemIDs => new List<int> {
            ItemID.JungleHat
        };

        public override float HeatComfortabilityChange => 1f;
    }

    public class JungleShirt : ItemChange {

        public override List<int> AppliedItemIDs => new List<int> {
            ItemID.JungleShirt
        };

        public override float HeatComfortabilityChange => 3f;
    }

    public class JunglePants : ItemChange {

        public override List<int> AppliedItemIDs => new List<int> {
            ItemID.JunglePants
        };

        public override float HeatComfortabilityChange => 1f;
    }

    public class JungleArmor : SetBonusChange {
        private readonly JungleClimate jungleClimateHumidity = new JungleClimate();

        public override List<int> HelmetPieceID => new List<int> {
            ItemID.JungleHat
        };

        public override int ChestPieceID => ItemID.JungleShirt;

        public override int LegPieceID => ItemID.JunglePants;

        public override string AdditionalSetBonusText => "Negates the humidity of the Jungle";

        public override void AdditionalSetBonusEffect(Player player) {
            if (player.ZoneJungle) {
                player.GetModPlayer<TempPlayer>().relativeHumidity -= jungleClimateHumidity.HumidityModification;
            }
        }
    }
}