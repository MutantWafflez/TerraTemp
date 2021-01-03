using Terraria.ID;
using System.Collections.Generic;
using Terraria;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class NecroHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.NecroHelmet,
            ItemID.AncientNecroHelmet
        };

        public override float CriticalTemperatureChange => 1f;
    }

    public class NecroChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.NecroBreastplate
        };

        public override float CriticalTemperatureChange => 1f;
    }

    public class NecroLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.NecroGreaves
        };

        public override float CriticalTemperatureChange => 1f;
    }

    public class NecroArmor : SetBonusChange {

        public override List<int> HelmetPieceID => new List<int>() {
            ItemID.NecroHelmet,
            ItemID.AncientNecroHelmet
        };

        public override int ChestPieceID => ItemID.NecroBreastplate;

        public override int LegPieceID => ItemID.NecroGreaves;

        public override float CriticalTemperatureChange => 2f;
    }
}