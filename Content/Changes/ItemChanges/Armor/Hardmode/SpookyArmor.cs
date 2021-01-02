using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class SpookyHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.SpookyHelmet
        };

        public override float TemperatureResistanceChange => -0.025f;
    }

    public class SpookyChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.SpookyBreastplate
        };

        public override float TemperatureResistanceChange => -0.05f;
    }

    public class SpookyLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.SpookyLeggings
        };

        public override float TemperatureResistanceChange => -0.025f;
    }

    public class SpookyArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.SpookyHelmet
        };

        public override int ChestPieceID => ItemID.SpookyBreastplate;

        public override int LegPieceID => ItemID.SpookyLeggings;

        public override string ArmorSetName => "SpookyArmor";

        public override float TemperatureResistanceChange => -0.4f;

        public override float CriticalTemperatureChange => 10f;
    }
}