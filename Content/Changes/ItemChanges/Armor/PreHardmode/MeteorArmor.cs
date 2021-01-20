using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Content.Changes.TempBiomes;
using TerraTemp.Custom;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class MeteorHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MeteorHelmet
        };

        public override float ColdComfortabilityChange => -2f;
    }

    public class MeteorChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MeteorSuit
        };

        public override float ColdComfortabilityChange => -3f;
    }

    public class MeteorLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MeteorLeggings
        };

        public override float ColdComfortabilityChange => -2f;
    }

    public class MeteorArmor : SetBonusChange {
        private readonly SpaceClimate spaceColdChange = new SpaceClimate();

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.MeteorHelmet
        };

        public override int ChestPieceID => ItemID.MeteorSuit;

        public override int LegPieceID => ItemID.MeteorLeggings;

        public override void AdditionalSetBonusEffect(Player player) {
            if (player.ZoneSkyHeight) {
                player.GetTempPlayer().baseDesiredTemperature -= spaceColdChange.TemperatureModification;
            }
        }
    }
}