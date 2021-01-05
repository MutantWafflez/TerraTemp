using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class WoodHelmets : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int> {
            ItemID.WoodHelmet,
            ItemID.BorealWoodHelmet,
            ItemID.PalmWoodHelmet,
            ItemID.RichMahoganyHelmet,
            ItemID.ShadewoodHelmet,
            ItemID.EbonwoodHelmet,
            ItemID.PearlwoodHelmet
        };

        public override float HeatComfortabilityChange => 0.5f;

        public override float ColdComfortabilityChange => -0.5f;
    }

    public class WoodChestplates : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int> {
            ItemID.WoodBreastplate,
            ItemID.BorealWoodBreastplate,
            ItemID.PalmWoodBreastplate,
            ItemID.RichMahoganyBreastplate,
            ItemID.ShadewoodBreastplate,
            ItemID.EbonwoodBreastplate,
            ItemID.PearlwoodBreastplate
        };

        public override float HeatComfortabilityChange => 1f;

        public override float ColdComfortabilityChange => -1f;
    }

    public class WoodLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int> {
            ItemID.WoodGreaves,
            ItemID.BorealWoodGreaves,
            ItemID.PalmWoodGreaves,
            ItemID.RichMahoganyGreaves,
            ItemID.ShadewoodGreaves,
            ItemID.EbonwoodGreaves,
            ItemID.PearlwoodGreaves
        };

        public override float HeatComfortabilityChange => 0.5f;

        public override float ColdComfortabilityChange => -0.5f;
    }
}