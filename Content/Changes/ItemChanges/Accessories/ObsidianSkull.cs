using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using TerraTemp.Content.Changes.TempBiomes;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes.ItemChanges.Accessories {

    public class ObsidianSkull : ItemChange {
        private readonly UnderworldClimate underworldClimate = new UnderworldClimate();

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            ItemID.ObsidianSkull,
        };

        public override bool DerivedItemsProvideEffects => true;

        public override float HeatComfortabilityChange => 2f;

        public override void AdditionalItemEquipEffect(Player player) {
            if (player.ZoneUnderworldHeight) {
                player.GetTempPlayer().baseDesiredTemperature -= underworldClimate.TemperatureModification * 0.4f;
            }
        }
    }
}