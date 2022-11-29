using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Localization;

namespace JenSaneFourPoint.Projectiles
{
    public class CosmicRay : ModProjectile
    {
        private float timer = 0;

        public override void SetDefaults()
        {
            Projectile.width = 6;
            Projectile.height = 6;
            Projectile.friendly = true;
            Projectile.DamageType = ModContent.GetInstance<PlagueDoctorDamageClass>();
            Projectile.tileCollide = true;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 100;
            Projectile.timeLeft = 100;
            Projectile.alpha = 255;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cosmic Ray");
        }

        public override void AI()
        {
            if (Projectile.velocity.X != Projectile.velocity.X)
            {
                Projectile.position.X = Projectile.position.X + Projectile.velocity.X;
                Projectile.velocity.X = -Projectile.velocity.X;
            }
            if (Projectile.velocity.Y != Projectile.velocity.Y)
            {
                Projectile.position.Y = Projectile.position.Y + Projectile.velocity.Y;
                Projectile.velocity.Y = -Projectile.velocity.Y;
            }
            timer += 1f;
            if (timer > 9f)
            {
                for (int k = 0; k < 1; k++)
                {
                    Projectile.position -= Projectile.velocity * ((float)k * 0.25f);
                    var dust = Dust.NewDust(Projectile.position, 1, 1, ModContent.DustType<RedLaser>(), 0f, 0f, 150, default, 1.5f);
                  //  dust.position = Projectile.position;
                  //  dust.velocity *= 0.1f;
                }
                return;
            }
        }
    }
}