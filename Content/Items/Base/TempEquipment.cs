using Terraria;
using TerraTemp.Custom;
using TerraTemp.Custom.Utilities;

namespace TerraTemp.Content.Base.Items {

    /// <summary>
    /// Abstract class that extends TempItem that has built in functionality adding Equipment that
    /// changes temperature statistics.
    /// </summary>
    public abstract class TempEquipment : TempItem {

        public override void UpdateEquip(Player player) {
            PlayerUtilities.ApplyStatChanges(this, player);
        }
    }
}