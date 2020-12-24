using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;

namespace TerraTemp.Utilities.ItemChanges.Accessories {
    public class LavaCharm : ItemChange {

        public override int AppliedItemID => ItemID.LavaCharm;

        public override List<int> ItemsThatContainThis => new List<int> {
            ItemID.LavaWaders
        };

        public override float HeatComfortabilityChange => 5f;

        public override string AdditionalTooltip => "5 degree increased heat comfortability range";
    }
}
