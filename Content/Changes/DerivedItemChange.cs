using System.Collections.Generic;
using System.Linq;
using Terraria;
using TerraTemp.Custom;
using TerraTemp.Custom.Attributes;

namespace TerraTemp.Content.Changes {

    /// <summary>
    /// Dynamic Item Change subclass for creating Item Changes on the fly.
    /// </summary>
    [IgnoredSubclass]
    public class DerivedItemChange : ItemChange {
        public readonly int appliedItemID;
        private readonly List<ItemChange> baseChanges = new List<ItemChange>();

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            appliedItemID
        };

        public override string AdditionalTooltip {
            get {
                string additionalLine = null;
                List<string> stringsToAdd = new List<string>();
                foreach (ItemChange baseChange in baseChanges) {
                    string returnedValue = TempUtilities.GetTerraTempTextValue("GlobalItemChange." + baseChange.GetType().Name);
                    if (returnedValue != "Mods.TerraTemp.GlobalItemChange." + baseChange.GetType().Name) {
                        stringsToAdd.Add(returnedValue);
                    }
                }
                if (stringsToAdd.Any()) {
                    additionalLine = "";
                    foreach (string line in stringsToAdd) {
                        additionalLine += line + (line != stringsToAdd.Last() ? "\n" : "");
                    }
                }
                return TempUtilities.CreateNewLineBasedOnStats(GetDesiredTemperatureChange(Main.LocalPlayer), GetHumidityChange(Main.LocalPlayer), GetHeatComfortabilityChange(Main.LocalPlayer), GetColdComfortabilityChange(Main.LocalPlayer), GetTemperatureResistanceChange(Main.LocalPlayer), GetCriticalTemperatureChange(Main.LocalPlayer), GetClimateExtremityChange(Main.LocalPlayer), additionalLine);
            }
        }

        public DerivedItemChange(int appliedItem, ItemChange baseChange) {
            appliedItemID = appliedItem;
            baseChanges.Add(baseChange);
        }

        public override float GetDesiredTemperatureChange(Player player) {
            float finalValue = 0f;
            foreach (ItemChange item in baseChanges) {
                finalValue += item.GetDesiredTemperatureChange(player);
            }
            return finalValue;
        }

        public override float GetHumidityChange(Player player) {
            float finalValue = 0f;
            foreach (ItemChange item in baseChanges) {
                finalValue += item.GetHumidityChange(player);
            }
            return finalValue;
        }

        public override float GetHeatComfortabilityChange(Player player) {
            float finalValue = 0f;
            foreach (ItemChange item in baseChanges) {
                finalValue += item.GetHeatComfortabilityChange(player);
            }
            return finalValue;
        }

        public override float GetColdComfortabilityChange(Player player) {
            float finalValue = 0f;
            foreach (ItemChange item in baseChanges) {
                finalValue += item.GetColdComfortabilityChange(player);
            }
            return finalValue;
        }

        public override float GetTemperatureResistanceChange(Player player) {
            float finalValue = 0f;
            foreach (ItemChange item in baseChanges) {
                finalValue += item.GetTemperatureResistanceChange(player);
            }
            return finalValue;
        }

        public override float GetCriticalTemperatureChange(Player player) {
            float finalValue = 0f;
            foreach (ItemChange item in baseChanges) {
                finalValue += item.GetCriticalTemperatureChange(player);
            }
            return finalValue;
        }

        public override float GetClimateExtremityChange(Player player) {
            float finalValue = 0f;
            foreach (ItemChange item in baseChanges) {
                finalValue += item.GetClimateExtremityChange(player);
            }
            return finalValue;
        }

        public override void AdditionalItemEquipEffect(Player player) {
            foreach (ItemChange itemChange in baseChanges) {
                itemChange.AdditionalItemEquipEffect(player);
            }
        }

        public List<ItemChange> GetBaseItemChanges() {
            return baseChanges;
        }

        /// <summary>
        /// Method that will attempt to merge this DerivedItemChange with <paramref
        /// name="secondChange"/>. Returns whether or not the merge was successful.
        /// </summary>
        public bool Merge(DerivedItemChange secondChange) {
            if (appliedItemID == secondChange.appliedItemID) {
                foreach (ItemChange itemChange in secondChange.baseChanges) {
                    if (!baseChanges.Contains(itemChange)) {
                        baseChanges.Add(itemChange);
                    }
                }
                return true;
            }
            else {
                return false;
            }
        }
    }
}