﻿using Terraria;
using Terraria.ModLoader;
using TerraTemp.Content.Changes;
using TerraTemp.Utilities;

namespace TerraTemp.Common.GlobalBuffs {

    /// <summary>
    /// GlobalBuff class that handles all the changes for vanilla buffs in the mod.
    /// </summary>
    public class VanillaBuffChanges : GlobalBuff {

        //Aditional effects on player based on the changes of a given buff
        public override void Update(int type, Player player, ref int buffIndex) {
            foreach (BuffChange change in TerraTemp.buffChanges) {
                if (type == change.AppliedBuffID) {
                    TempPlayer temperaturePlayer = player.GetTempPlayer();
                    temperaturePlayer.baseDesiredTemperature += change.DesiredTemperatureChange;
                    temperaturePlayer.comfortableHigh += change.HeatComfortabilityChange;
                    temperaturePlayer.comfortableLow += change.ColdComfortabilityChange;
                    temperaturePlayer.temperatureChangeResist += change.TemperatureResistanceChange;
                    temperaturePlayer.criticalRangeMaximum += change.CriticalTemperatureChange;
                    break;
                }
            }
        }

        //Modification of a given buff's tip based on the respective (if applicable) vanilla buff change
        public override void ModifyBuffTip(int type, ref string tip, ref int rare) {
            foreach (BuffChange change in TerraTemp.buffChanges) {
                if (type == change.AppliedBuffID && change.AdditionalBuffTip != null) {
                    tip += "\n" + change.AdditionalBuffTip;
                }
            }
        }
    }
}