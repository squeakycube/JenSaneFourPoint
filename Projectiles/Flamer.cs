using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace JenSaneFourPoint.Projectiles
{
	public class Flamer : ModProjectile
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Flamer"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults() 
		{
			Projectile.aiStyle = 1;
			//projectile.friendly = true;
			Projectile.penetrate = 3;
			Projectile.damage = 220;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.width = 52;
			Projectile.height = 50;
			Projectile.knockBack = 6;
			Projectile.tileCollide = false;
						Projectile.extraUpdates = 1;            //Set to above 0 if you want the projectile to update multiple time in a frame
									Projectile.friendly = true;         //Can the projectile deal damage to enemies?
			Projectile.hostile = false;         //Can the projectile deal damage to the player?
		}

		public void OnHitNPC(ExamplePlayer player, NPC target, int buffIndex)
				{
			// Add the Onfire buff to the NPC for 1 second when the weapon hits an NPC
			// 60 frames = 1 second
			target.AddBuff(BuffID.OnFire, 1200);
		}

		public override void AI()
		{
			Lighting.AddLight(Projectile.Center, 2.55f, 0.92f, 0.07f);
			
			//projectile.rotation -= 1.57f;
			//projectile.velocity.Y -= 0.785f;

		}
	}
}