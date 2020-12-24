using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTemp.Utilities {
    public abstract class ItemChanges {

        /// <summary>
        /// The ID of the item to be modified.
        /// </summary>
        public virtual int ItemID => -1;

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
    }
}
