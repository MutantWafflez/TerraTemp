using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Content.Items.Accessories;
using TerraTemp.Custom;

namespace TerraTemp.Common.Players {

    /// <summary>
    /// Player that handles the accessory items in this mod.
    /// </summary>
    public class AccessoryPlayer : ModPlayer {
        public bool flameRune;
        public bool frostRune;
        public bool volatileThermometer;

        public override void ResetEffects() {
            flameRune = false;
            frostRune = false;
            volatileThermometer = false;
        }

        public override void PostUpdateEquips() {
            TempPlayer temperaturePlayer = Player.GetTempPlayer();
            if (flameRune) {
                if (temperaturePlayer.currentTemperature > TempPlayer.NormalTemperature) {
                    //TODO: Re-implement damage increase
                    //Player.allDamageMult += 0.02f * (temperaturePlayer.currentTemperature - TempPlayer.NormalTemperature);
                    Player.moveSpeed *= 1 + (0.02f * (temperaturePlayer.currentTemperature - TempPlayer.NormalTemperature));
                }
            }

            if (frostRune) {
                if (temperaturePlayer.currentTemperature < TempPlayer.NormalTemperature) {
                    Player.statDefense = (int)Math.Round(Player.statDefense * (1f + (0.02f * (TempPlayer.NormalTemperature - temperaturePlayer.currentTemperature))));
                    Player.endurance += 0.02f * (TempPlayer.NormalTemperature - temperaturePlayer.currentTemperature);
                }
            }
        }
    }
}