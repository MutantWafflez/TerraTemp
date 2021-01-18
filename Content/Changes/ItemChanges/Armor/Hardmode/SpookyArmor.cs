using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class SpookyHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SpookyHelmet
        };

        public override float TemperatureResistanceChange => -0.025f;
    }

    public class SpookyChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SpookyBreastplate
        };

        public override float TemperatureResistanceChange => -0.05f;
    }

    public class SpookyLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.SpookyLeggings
        };

        public override float TemperatureResistanceChange => -0.025f;
    }

    public class SpookyArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.SpookyHelmet
        };

        public override int ChestPieceID => ItemID.SpookyBreastplate;

        public override int LegPieceID => ItemID.SpookyLeggings;

        public override float TemperatureResistanceChange => -0.4f;

        public override float CriticalTemperatureChange => 6f;
    }
}