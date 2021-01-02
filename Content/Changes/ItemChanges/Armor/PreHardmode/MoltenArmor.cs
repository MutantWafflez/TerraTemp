using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class MoltenHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.MoltenHelmet
        };

        public override float DesiredTemperatureChange => 2f;
    }

    public class MoltenChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.MoltenBreastplate
        };

        public override float DesiredTemperatureChange => 4f;
    }

    public class MoltenLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.MoltenGreaves
        };

        public override float DesiredTemperatureChange => 2f;
    }

    public class MoltenArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.MoltenHelmet
        };

        public override int ChestPieceID => ItemID.MoltenBreastplate;

        public override int LegPieceID => ItemID.MoltenGreaves;

        public override string ArmorSetName => "MoltenArmor";

        public override float ColdComfortabilityChange => -8f;

        public override string AdditionalSetBonusText => base.AdditionalSetBonusText;
    }
}