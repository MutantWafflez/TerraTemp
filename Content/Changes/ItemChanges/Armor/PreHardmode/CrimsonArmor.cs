using Terraria.ID;
using System.Collections.Generic;
using Terraria;
using TerraTemp.Content.Changes.EvilTempBiomes;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class CrimsonHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.CrimsonHelmet
        };

        public override float TemperatureResistanceChange => 0.0125f;
    }

    public class CrimsonChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.CrimsonScalemail
        };

        public override float TemperatureResistanceChange => 0.025f;
    }

    public class CrimsonLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.CrimsonGreaves
        };

        public override float TemperatureResistanceChange => 0.0125f;
    }

    public class CrimsonArmor : SetBonusChange {
        private readonly CrimsonClimate crimsonHumidityChange = new CrimsonClimate();

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.CrimsonHelmet
        };

        public override int ChestPieceID => ItemID.CrimsonScalemail;

        public override int LegPieceID => ItemID.CrimsonGreaves;

        public override void AdditionalSetBonusEffect(Player player) {
            if (player.ZoneCrimson) {
                player.GetTempPlayer().relativeHumidity -= crimsonHumidityChange.HumidityModification;
            }
        }
    }
}