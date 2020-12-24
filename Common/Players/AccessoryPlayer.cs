using System;
using Terraria.ModLoader;

namespace TerraTemp.Common.Players {

    /// <summary>
    /// Player that handles the accessory items in this mod.
    /// </summary>
    public class AccessoryPlayer : ModPlayer {
        public bool flameRune;
        public bool frostRune;

        public override void ResetEffects() {
            flameRune = false;
            frostRune = false;
        }

        public override void PostUpdateEquips() {
            TempPlayer temperaturePlayer = player.GetModPlayer<TempPlayer>();
            if (flameRune) {
                temperaturePlayer.comfortableLow += 5f;
                if (temperaturePlayer.currentTemperature > TempPlayer.NormalTemperature) {
                    player.allDamageMult += 0.02f * (temperaturePlayer.currentTemperature - TempPlayer.NormalTemperature);
                    player.moveSpeed *= 1 + (0.02f * (temperaturePlayer.currentTemperature - TempPlayer.NormalTemperature));
                }
            }

            if (frostRune) {
                temperaturePlayer.comfortableHigh -= 5f;
                if (temperaturePlayer.currentTemperature < TempPlayer.NormalTemperature) {
                    player.statDefense = (int)Math.Round(player.statDefense * (1f + (0.02f * (TempPlayer.NormalTemperature - temperaturePlayer.currentTemperature))));
                    player.endurance += 0.02f * (TempPlayer.NormalTemperature - temperaturePlayer.currentTemperature);
                }
            }
        }
    }
}