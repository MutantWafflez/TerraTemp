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
            ItemID.ObsidianWaterWalkingBoots,
            ItemID.ObsidianShield,
            ItemID.AnkhShield
        };

        public override float HeatComfortabilityChange => 2f;

        public override string AdditionalTooltip => base.AdditionalTooltip + "\n" + TempUtilities.GetTerraTempTextValue("GlobalItemChange.ObsidianSkull");

        public override void AdditionalItemEquipEffect(Player player) {
            if (player.ZoneUnderworldHeight) {
                player.GetTempPlayer().baseDesiredTemperature -= underworldClimate.TemperatureModification * 0.4f;
            }
        }
    }
}