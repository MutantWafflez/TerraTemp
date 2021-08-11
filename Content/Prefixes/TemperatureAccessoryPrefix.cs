using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using TerraTemp.Common.GlobalItems;
using TerraTemp.Custom;
using TerraTemp.Custom.Interfaces;
using TerraTemp.Custom.Structs;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Content.Prefixes {

    public abstract class TemperatureAccessoryPrefix : ModPrefix, ITempStatChange {
        public List<ColoredString> PrefixTooltips => LocalizationUtilities.CreatePrefixStatLines(this);

        public override PrefixCategory Category => PrefixCategory.Accessory;

        public virtual float GetDesiredTemperatureChange(Player player) => 0f;

        public virtual float GetHumidityChange(Player player) => 0f;

        public virtual float GetHeatComfortabilityChange(Player player) => 0f;

        public virtual float GetColdComfortabilityChange(Player player) => 0f;

        public virtual float GetTemperatureResistanceChange(Player player) => 0f;

        public virtual float GetCriticalTemperatureChange(Player player) => 0f;

        public virtual float GetClimateExtremityChange(Player player) => 0f;

        public virtual float GetSunExtremityChange(Player player) => 0f;

        public override void Apply(Item item) {
            base.Apply(item);
            item.GetGlobalItem<CustomPrefixItem>().appliedAccessoryPrefix = this;
        }
    }
}