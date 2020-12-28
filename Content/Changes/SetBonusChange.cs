using System.Collections.Generic;
using Terraria;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Changes {

    public abstract class SetBonusChange {

        /// <summary>
        /// The ID of the helmet piece(s) item of the armor set. Is a list for armor sets that have
        /// different head pieces, such as the Hardmode ore armors.
        /// </summary>
        public virtual List<int> HelmetPieceID => new List<int>();

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
        /// </summary>
        public virtual string ArmorSetName => null;

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
        /// Additional tooltip line(s) to be added to the end of the set bonus text. Done
        /// automatically based on how each property is changed, if you wish to add an additional
        /// line on top of this, use base.AdditionalSetBonusText + "your string here"
        /// </summary>
        public virtual string AdditionalSetBonusText => TempUtilities.CreateNewLineBasedOnStats(HeatComfortabilityChange, ColdComfortabilityChange, TemperatureResistanceChange, CriticalTemperatureChange);

        /// <summary>
        /// If the set bonus has an additional effect on the player, overriding this method can
        /// assist with whatever change. This hook is called in the UpdateArmorSet() hook in the
        /// VanillaItemChange GlobalItem.
        /// </summary>
        /// <param name="player"> </param>
        public virtual void AdditionalSetBonusEffect(Player player) { }
    }
}