using System.Collections.Generic;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class NecroHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.NecroHelmet,
            ItemID.AncientNecroHelmet
        };

        public override float CriticalTemperatureChange => 1f;
    }

    public class NecroChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.NecroBreastplate
        };

        public override float CriticalTemperatureChange => 1f;
    }

    public class NecroLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.NecroGreaves
        };

        public override float CriticalTemperatureChange => 1f;
    }

    public class NecroArmor : SetBonusChange {

        public override HashSet<int> HelmetPieceID => new HashSet<int>() {
            ItemID.NecroHelmet,
            ItemID.AncientNecroHelmet
        };

        public override int ChestPieceID => ItemID.NecroBreastplate;

        public override int LegPieceID => ItemID.NecroGreaves;

        public override float CriticalTemperatureChange => 2f;
    }
}