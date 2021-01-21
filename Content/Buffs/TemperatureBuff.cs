using Terraria;
using Terraria.ModLoader;
using TerraTemp.Custom;
using TerraTemp.Custom.Interfaces;

namespace TerraTemp.Content.Buffs {

    /// <summary>
    /// Abstract class overriding the ModBuff class that automatically creates localization for the
    /// buff description. Also has new virtual properties that can be overriden to automatically
    /// change a player's temperature stats.
    /// </summary>
    public abstract class TemperatureBuff : ModBuff, ITempStatChange {

        /// <summary>
        /// By how much this given buff will change the player's Base Desired (Environmental) Temperature.
        /// </summary>
        public virtual float GetDesiredTemperatureChange(Player player) => 0f;

        /// <summary>
        /// By how much this given buff will change the player's Relative Humidity.
        /// </summary>
        public virtual float GetHumidityChange(Player player) => 0f;

        /// <summary>
        /// By how much this given buff will change the player's Heat Comfortability Range.
        /// </summary>
        public virtual float GetHeatComfortabilityChange(Player player) => 0f;

        /// <summary>
        /// By how much this given buff will change the player's Cold Comfortability Range.
        /// </summary>
        public virtual float GetColdComfortabilityChange(Player player) => 0f;

        /// <summary>
        /// By how much this given buff will change the player's Temperature Resistance.
        /// </summary>
        public virtual float GetTemperatureResistanceChange(Player player) => 0f;

        /// <summary>
        /// By how much this given buff will change the player's critical temperature range.
        /// </summary>
        public virtual float GetCriticalTemperatureChange(Player player) => 0f;

        /// <summary>
        /// By how much this given buff will change the player's climate extremity value.
        /// </summary>
        public virtual float GetClimateExtremityChange(Player player) => 0f;

        /// <summary>
        /// By how much this given buff will change the player's sun extremity value (sun
        /// protection, essentially).
        /// </summary>
        public virtual float GetSunExtremityChange(Player player) => 0f;

        public override void Update(Player player, ref int buffIndex) {
            TempPlayer temperaturePlayer = player.GetTempPlayer();
            temperaturePlayer.baseDesiredTemperature += GetDesiredTemperatureChange(player);
            temperaturePlayer.comfortableHigh += GetHeatComfortabilityChange(player);
            temperaturePlayer.comfortableLow += GetColdComfortabilityChange(player);
            temperaturePlayer.temperatureChangeResist += GetTemperatureResistanceChange(player);
            temperaturePlayer.criticalRangeMaximum += GetCriticalTemperatureChange(player);
            temperaturePlayer.climateExtremityValue += GetClimateExtremityChange(player);
        }

        public override void ModifyBuffTip(ref string tip, ref int rare) {
            string returnedLine = TempUtilities.CreateNewLineBasedOnStats(this);
            if (returnedLine != null) {
                tip = returnedLine;
            }
        }
    }
}