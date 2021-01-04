using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.Hardmode {

    public class SolarFlareHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.SolarFlareHelmet
        };
    }

    public class SolarFlareChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.SolarFlareBreastplate
        };
    }

    public class SolarFlareLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.SolarFlareLeggings
        };
    }

    public class SolarFlareArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.SolarFlareHelmet
        };

        public override int ChestPieceID => ItemID.SolarFlareBreastplate;

        public override int LegPieceID => ItemID.SolarFlareLeggings;
    }
}