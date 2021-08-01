using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TerraTemp.Content.Items.Accessories;
using TerraTemp.Content.Projectiles;
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

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource) {
            if (volatileThermometer && damageSource.SourceItemType == ModContent.ItemType<VolatileThermometer>()) {
                Item volatileThermometer = new Item();
                volatileThermometer.SetDefaults(ModContent.ItemType<VolatileThermometer>());
                Projectile.NewProjectile(new ProjectileSource_Item(Player, volatileThermometer), Player.Center, Vector2.Zero, ModContent.ProjectileType<ThermometerExplosion>(), 1000, 4f, Player.whoAmI);
                SoundEngine.PlaySound(SoundID.Item100, Player.Center);
            }
        }
    }
}