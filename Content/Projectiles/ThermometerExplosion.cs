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
            projectile.hide = true;
            projectile.friendly = true;
            projectile.width = 16 * 32; //32 blocks across
            projectile.height = 16 * 32; //32 blocks high
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = 999;
            projectile.velocity = Vector2.Zero;
            projectile.timeLeft = 10;
            projectile.aiStyle = -1;
        }

        public override void AI() {
            for (int j = 0; j < 360; j += 15) {
                Dust dust = Dust.NewDustPerfect(projectile.Center, DustID.Fire, new Vector2(0, -projectile.timeLeft * 2.5f).RotatedBy(MathHelper.ToRadians(j)), Scale: 2.5f);
                dust.noGravity = true;
            }
        }
    }
}