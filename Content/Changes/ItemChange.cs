using System.Collections.Generic;
using Terraria;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes {

    /// <summary>
    /// Abstract class that can be inherited and its fields overriden for any potential change to
    /// ANY given item.
    /// </summary>
    public abstract class ItemChange {

        /// <summary>
        /// List of Item IDs that this change pertains to. The reason this is a list is for if the
        /// base item is a material (such as the Lava charm), and its effects are carried over into
        /// the new accessory (Lava Waders, with the example of the Lava Charm)
        /// </summary>
        public virtual HashSet<int> AppliedItemIDs => new HashSet<int>();

        /// <summary>
        /// Whether or not the items that are crafting from this item will retain the effects. For
        /// example, if this is set to true on the Obsidian Skull, all accessories that have the
        /// Obsidian Skull ANYWHERE in the crafting tree will retain the effects of the Obsidian Skull.
        /// </summary>
        public virtual bool DerivedItemsProvideEffects => false;

        /// <summary>
        /// By how much this given item will change the player's Base Desired (Environmental) Temperature.
        /// </summary>
        public virtual float DesiredTemperatureChange => 0f;

        /// <summary>
        /// By how much this given item will change the player's Heat Comfortability Range.
        /// </summary>
        public virtual float HeatComfortabilityChange => 0f;

        /// <summary>
        /// By how much this given item will change the player's Cold Comfortability Range.
        /// </summary>
        public virtual float ColdComfortabilityChange => 0f;

        /// <summary>
        /// By how much this given item will change the player's Temperature Resistance.
        /// </summary>
        public virtual float TemperatureResistanceChange => 0f;

        /// <summary>
        /// By how much this given item will change the player's critical temperature range.
        /// </summary>
        public virtual float CriticalTemperatureChange => 0f;

        /// <summary>
        /// By how much this given item will change the player's climate extremity value.
        /// </summary>
        public virtual float ClimateExtremityChange => 0f;

        /// <summary>
        /// Additional tooltip line(s) to be added to the end of the item's tooltip. Done
        /// automatically based on how each property is changed.
        /// </summary>
        public virtual string AdditionalTooltip {
            get {
                string additionalLine = TempUtilities.GetTerraTempTextValue("GlobalItemChange." + GetType().Name);
                if (additionalLine == "Mods.TerraTemp.GlobalItemChange." + GetType().Name) {
                    additionalLine = null;
                }
                return TempUtilities.CreateNewLineBasedOnStats(HeatComfortabilityChange, ColdComfortabilityChange, TemperatureResistanceChange, CriticalTemperatureChange, DesiredTemperatureChange, ClimateExtremityChange, additionalLine);
            }
        }

        /// <summary>
        /// If the item has an additional effect on the player, overriding this method can assist
        /// with whatever change. This hook is called in the UpdateEquip() hook in the
        /// VanillaItemChange GlobalItem.
        /// </summary>
        /// <param name="player"> Player that has this item equipped. </param>
        public virtual void AdditionalItemEquipEffect(Player player) { }
    }
}