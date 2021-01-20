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
        private List<ItemChange> baseChanges = new List<ItemChange>();

        public override HashSet<int> AppliedItemIDs => new HashSet<int>() {
            appliedItemID
        };

        public override float ClimateExtremityChange {
            get {
                float finalValue = 0f;
                foreach (ItemChange item in baseChanges) {
                    finalValue += item.ClimateExtremityChange;
                }
                return finalValue;
            }
        }

        public override float ColdComfortabilityChange {
            get {
                float finalValue = 0f;
                foreach (ItemChange item in baseChanges) {
                    finalValue += item.ColdComfortabilityChange;
                }
                return finalValue;
            }
        }

        public override float CriticalTemperatureChange {
            get {
                float finalValue = 0f;
                foreach (ItemChange item in baseChanges) {
                    finalValue += item.CriticalTemperatureChange;
                }
                return finalValue;
            }
        }

        public override float DesiredTemperatureChange {
            get {
                float finalValue = 0f;
                foreach (ItemChange item in baseChanges) {
                    finalValue += item.DesiredTemperatureChange;
                }
                return finalValue;
            }
        }

        public override float HeatComfortabilityChange {
            get {
                float finalValue = 0f;
                foreach (ItemChange item in baseChanges) {
                    finalValue += item.HeatComfortabilityChange;
                }
                return finalValue;
            }
        }

        public override float TemperatureResistanceChange {
            get {
                float finalValue = 0f;
                foreach (ItemChange item in baseChanges) {
                    finalValue += item.TemperatureResistanceChange;
                }
                return finalValue;
            }
        }

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
                return TempUtilities.CreateNewLineBasedOnStats(HeatComfortabilityChange, ColdComfortabilityChange, TemperatureResistanceChange, CriticalTemperatureChange, DesiredTemperatureChange, ClimateExtremityChange, additionalLine);
            }
        }

        public DerivedItemChange(int appliedItem, ItemChange baseChange) {
            appliedItemID = appliedItem;
            baseChanges.Add(baseChange);
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