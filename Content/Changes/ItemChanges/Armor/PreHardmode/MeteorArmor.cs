using Terraria.ID;
using System.Collections.Generic;
using Terraria;
using TerraTemp.Content.Changes.TempBiomes;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class MeteorHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.MeteorHelmet
        };

        public override float ColdComfortabilityChange => -2f;
    }

    public class MeteorChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.MeteorSuit
        };

        public override float ColdComfortabilityChange => -3f;
    }

    public class MeteorLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.MeteorLeggings
        };

        public override float ColdComfortabilityChange => -2f;
    }

    public class MeteorArmor : SetBonusChange {
        private readonly SpaceClimate spaceColdChange = new SpaceClimate();

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.MeteorHelmet
        };

        public override int ChestPieceID => ItemID.MeteorSuit;

        public override int LegPieceID => ItemID.MeteorLeggings;

        public override void AdditionalSetBonusEffect(Player player) {
            if (player.ZoneSkyHeight) {
                player.GetModPlayer<TempPlayer>().baseDesiredTemperature -= spaceColdChange.TemperatureModification;
            }
        }
    }
}