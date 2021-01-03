using Terraria.ID;
using System.Collections.Generic;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class MiningHelmet : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.MiningHelmet
        };

        public override float HeatComfortabilityChange => 0.5f;

        public override float ColdComfortabilityChange => -0.5f;

        public override float TemperatureResistanceChange => 0.0025f;
    }

    public class MiningChestplate : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.MiningShirt
        };

        public override float HeatComfortabilityChange => 1f;

        public override float ColdComfortabilityChange => -1f;

        public override float TemperatureResistanceChange => 0.005f;
    }

    public class MiningLeggings : ItemChange {

        public override List<int> AppliedItemIDs => new List<int>() {
            ItemID.MiningPants
        };

        public override float HeatComfortabilityChange => 0.5f;

        public override float ColdComfortabilityChange => -0.5f;

        public override float TemperatureResistanceChange => 0.0025f;
    }
}