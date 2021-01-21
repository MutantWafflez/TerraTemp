using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Content.Changes.ItemChanges.Armor.PreHardmode {

    public class MiningHelmet : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MiningHelmet
        };

        public override float GetHeatComfortabilityChange(Player player) => 0.5f;

        public override float GetColdComfortabilityChange(Player player) => -0.5f;

        public override float GetTemperatureResistanceChange(Player player) => 0.0025f;
    }

    public class MiningChestplate : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MiningShirt
        };

        public override float GetHeatComfortabilityChange(Player player) => 1f;

        public override float GetColdComfortabilityChange(Player player) => -1f;

        public override float GetTemperatureResistanceChange(Player player) => 0.005f;
    }

    public class MiningLeggings : ItemChange {

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.MiningPants
        };

        public override float GetHeatComfortabilityChange(Player player) => 0.5f;

        public override float GetColdComfortabilityChange(Player player) => -0.5f;

        public override float GetTemperatureResistanceChange(Player player) => 0.0025f;
    }
}