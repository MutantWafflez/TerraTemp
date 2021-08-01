using Terraria;
using Terraria.ModLoader;
using TerraTemp.Common.Systems;
using TerraTemp.Content.Changes;
using TerraTemp.Custom;

namespace TerraTemp.Common.GlobalBuffs {

    /// <summary>
    /// GlobalBuff class that handles all the changes for vanilla buffs in the mod.
    /// </summary>
    public class VanillaBuffChanges : GlobalBuff {

        //Aditional effects on player based on the changes of a given buff
        public override void Update(int type, Player player, ref int buffIndex) {
            foreach (BuffChange buffChange in ContentListSystem.buffChanges) {
                if (type == buffChange.AppliedBuffID) {
                    TempUtilities.ApplyStatChanges(buffChange, player);
                }
            }
        }

        //Modification of a given buff's tip based on the respective (if applicable) vanilla buff change
        public override void ModifyBuffTip(int type, ref string tip, ref int rare) {
            foreach (BuffChange buffChange in ContentListSystem.buffChanges) {
                if (type == buffChange.AppliedBuffID && buffChange.AdditionalBuffTip != null) {
                    tip += "\n" + buffChange.AdditionalBuffTip;
                }
            }
        }
    }
}