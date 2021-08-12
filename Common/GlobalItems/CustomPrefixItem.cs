using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.Utilities;
using TerraTemp.Content.Prefixes;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Common.GlobalItems {

    /// <summary>
    /// GlobalItem that handles the custom prefixes for TerraTemp and applies them properly, along
    /// with the tooltips.
    /// </summary>
    public class CustomPrefixItem : GlobalItem {
        public TemperatureAccessoryPrefix appliedAccessoryPrefix;

        public override bool InstancePerEntity => true;

        public CustomPrefixItem() {
            appliedAccessoryPrefix = null;
        }

        public override GlobalItem Clone(Item item, Item itemClone) {
            CustomPrefixItem cloneItem = (CustomPrefixItem)base.Clone(item, itemClone);
            cloneItem.appliedAccessoryPrefix = appliedAccessoryPrefix;
            return cloneItem;
        }

        public override int ChoosePrefix(Item item, UnifiedRandom rand) {
            appliedAccessoryPrefix = null;
            return base.ChoosePrefix(item, rand);
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
            if (!item.social && item.prefix > 0 && appliedAccessoryPrefix != null) {
                for (int i = 0; i < appliedAccessoryPrefix.PrefixTooltips.Count; i++) {
                    tooltips.Add(new TooltipLine(Mod, "TemperaturePrefix" + i, appliedAccessoryPrefix.PrefixTooltips[i].value) {
                        overrideColor = appliedAccessoryPrefix.PrefixTooltips[i].stringColor
                    });
                }
            }
        }

        public override void UpdateAccessory(Item item, Player player, bool hideVisual) {
            if (appliedAccessoryPrefix != null) {
                PlayerUtilities.ApplyStatChanges(appliedAccessoryPrefix, player);
            }
        }
    }
}