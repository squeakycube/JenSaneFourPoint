using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace JenSaneFourPoint.Projectiles
{
	public class ThrowPot : ModProjectile
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("ThrowPot"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults() 
		{
			Projectile.aiStyle = 1;
			//projectile.friendly = true;
			Projectile.penetrate = 3;
            Projectile.damage = 220;
            //Projectile.damage = 22;
            Projectile.DamageType = ModContent.GetInstance<PlaugeDoctorDamageClass>();
            Projectile.width = 52;
			Projectile.height = 50;
			Projectile.knockBack = 6;
			Projectile.tileCollide = false;
						Projectile.extraUpdates = 1;            //Set to above 0 if you want the projectile to update multiple time in a frame
									Projectile.friendly = true;         //Can the projectile deal damage to enemies?
			Projectile.hostile = false;         //Can the projectile deal damage to the player?
		}

		public override void AI()
		{
			Lighting.AddLight(Projectile.Center, 0f, 2.55f, 2.51f);
			
			//projectile.rotation -= 1.57f;
			//projectile.velocity.Y -= 0.785f;

		}

 //       public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
 //       {
 //           if (Main.rand.NextBool(2))
 //           {
 //           int lifeSteal = damage / 3;
 //           player.statLife += 100;
 //           player.HealEffect(100, true);
 //           }
 //       }

    }
}