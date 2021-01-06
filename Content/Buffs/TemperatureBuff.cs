using Terraria;
using Terraria.ModLoader;
using TerraTemp.Utilities;

namespace TerraTemp.Content.Buffs {

    /// <summary>
    /// Abstract class overriding the ModBuff class that automatically creates localization for the
    /// buff description. Also has new virtual properties that can be overriden to automatically
    /// change a player's temperature stats.
    /// </summary>
    public abstract class TemperatureBuff : ModBuff {

        /// <summary>
        /// By how much this given buff will change the player's Base Desired (Environmental) Temperature.
        /// </summary>
        public virtual float DesiredTemperatureChange => 0f;

        /// <summary>
        /// By how much this given buff will change the player's Heat Comfortability Range.
        /// </summary>
        public virtual float HeatComfortabilityChange => 0f;

        /// <summary>
        /// By how much this given buff will change the player's Cold Comfortability Range.
        /// </summary>
        public virtual float ColdComfortabilityChange => 0f;

        /// <summary>
        /// By how much this given buff will change the player's Temperature Resistance.
        /// </summary>
        public virtual float TemperatureResistanceChange => 0f;

        /// <summary>
        /// By how much this given buff will change the player's critical temperature range.
        /// </summary>
        public virtual float CriticalTemperatureChange => 0f;

        public override void Update(Player player, ref int buffIndex) {
            TempPlayer temperaturePlayer = player.GetTempPlayer();
            temperaturePlayer.baseDesiredTemperature += DesiredTemperatureChange;
            temperaturePlayer.comfortableHigh += HeatComfortabilityChange;
            temperaturePlayer.comfortableLow += ColdComfortabilityChange;
            temperaturePlayer.temperatureChangeResist += TemperatureResistanceChange;
            temperaturePlayer.criticalRangeMaximum += CriticalTemperatureChange;
        }

        public override void ModifyBuffTip(ref string tip, ref int rare) {
            string returnedLine = TempUtilities.CreateNewLineBasedOnStats(HeatComfortabilityChange, ColdComfortabilityChange, TemperatureResistanceChange, CriticalTemperatureChange, DesiredTemperatureChange);
            if (returnedLine != null) {
                tip = returnedLine;
            }
        }
    }
}