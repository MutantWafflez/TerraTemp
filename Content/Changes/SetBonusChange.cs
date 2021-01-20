using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using TerraTemp.Custom;

namespace TerraTemp.Content.Changes {

    /// <summary>
    /// Abstract class that can be inherited and its fields overriden to add to ANY Armor Set bonus.
    /// </summary>
    public abstract class SetBonusChange {

        /// <summary>
        /// The ID of the helmet piece(s) item of the armor set. Is a list for armor sets that have
        /// different head pieces, such as the Hardmode ore armors.
        /// </summary>
        public virtual HashSet<int> HelmetPieceID => new HashSet<int>();

        /// <summary>
        /// The ID of the chest piece item of the armor set.
        /// </summary>
        public virtual int ChestPieceID => -1;

        /// <summary>
        /// The ID of the leg piece item of the armor set.
        /// </summary>
        public virtual int LegPieceID => -1;

        /// <summary>
        /// Name of the armor set so the Global Item can identify it properly and apply the effects.
        /// Defaults to the class name.
        /// </summary>
        public string ArmorSetName => GetType().Name;

        /// <summary>
        /// By how much this given set bonus will change the player's Base Desired (Environmental) Temperature.
        /// </summary>
        public virtual float DesiredTemperatureChange => 0f;

        /// <summary>
        /// By how much this given set bonus will change the player's Heat Comfortability Range.
        /// </summary>
        public virtual float HeatComfortabilityChange => 0f;

        /// <summary>
        /// By how much this given set bonus will change the player's Cold Comfortability Range.
        /// </summary>
        public virtual float ColdComfortabilityChange => 0f;

        /// <summary>
        /// By how much this given set bonus will change the player's Temperature Resistance.
        /// </summary>
        public virtual float TemperatureResistanceChange => 0f;

        /// <summary>
        /// By how much this given set bonus will change the player's critical temperature range.
        /// </summary>
        public virtual float CriticalTemperatureChange => 0f;

        /// <summary>
        /// By how much this given set bonus will change the player's climate extremity value.
        /// </summary>
        public virtual float ClimateExtremityChange => 0f;

        /// <summary>
        /// Additional tooltip line(s) to be added to the end of the set bonus text. Done
        /// automatically based on how each property is changed. If there is a unique effect other
        /// than changing stats, unless you want it to not be localized, the tooltip is
        /// automatically localized if there is a key for it.
        /// </summary>
        public virtual string AdditionalSetBonusText {
            get {
                string statLine = TempUtilities.CreateNewLineBasedOnStats(HeatComfortabilityChange, ColdComfortabilityChange, TemperatureResistanceChange, CriticalTemperatureChange, DesiredTemperatureChange, ClimateExtremityChange);
                if (statLine != null) {
                    if (Language.Exists("Mods.TerraTemp.GlobalSetBonus." + ArmorSetName)) {
                        return statLine + "\n" + TempUtilities.GetTerraTempTextValue("GlobalSetBonus." + ArmorSetName, useRegexSearch: true);
                    }
                    return statLine;
                }
                else {
                    if (Language.Exists("Mods.TerraTemp.GlobalSetBonus." + ArmorSetName)) {
                        return TempUtilities.GetTerraTempTextValue("GlobalSetBonus." + ArmorSetName, useRegexSearch: true);
                    }
                    return null;
                }
            }
        }

        /// <summary>
        /// If the set bonus has an additional effect on the player, overriding this method can
        /// assist with whatever change. This hook is called in the UpdateArmorSet() hook in the
        /// VanillaItemChange GlobalItem.
        /// </summary>
        /// <param name="player"> </param>
        public virtual void AdditionalSetBonusEffect(Player player) { }
    }
}