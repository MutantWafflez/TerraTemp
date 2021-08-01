using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraTemp.Content.Projectiles {

    public class ThermometerExplosion : ModProjectile {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.None;

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Thermometer Explosion");
        }

        public override void SetDefaults() {
            Projectile.hide = true;
            Projectile.friendly = true;
            Projectile.width = 16 * 32; //32 blocks across
            Projectile.height = 16 * 32; //32 blocks high
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = 999;
            Projectile.velocity = Vector2.Zero;
            Projectile.timeLeft = 10;
            Projectile.aiStyle = -1;
        }

        public override void AI() {
            for (int j = 0; j < 360; j += 15) {
                Dust dust = Dust.NewDustPerfect(Projectile.Center, DustID.Fireworks, new Vector2(0, -Projectile.timeLeft * 2.5f).RotatedBy(MathHelper.ToRadians(j)), Scale: 2.5f);
                dust.noGravity = true;
            }
        }
    }
}