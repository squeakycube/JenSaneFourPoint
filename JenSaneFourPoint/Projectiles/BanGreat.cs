using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace JenSaneFourPoint.Projectiles
{
	public class BanGreat : ModProjectile
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("GreaterBananarang"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults() 
		{
			Projectile.aiStyle = 3;
				Projectile.CloneDefaults(ProjectileID.Bananarang);
	// projectile.aiStyle = 3; This line is not needed since CloneDefaults sets it.
	AIType = ProjectileID.Bananarang;
			//projectile.friendly = true;
			Projectile.penetrate = 3;
			Projectile.damage = 85;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.width = 52;
			Projectile.height = 50;
			Projectile.knockBack = 9;
			Projectile.tileCollide = false;
						Projectile.extraUpdates = 1;            //Set to above 0 if you want the projectile to update multiple time in a frame
									Projectile.friendly = true;         //Can the projectile deal damage to enemies?
			Projectile.hostile = false;         //Can the projectile deal damage to the player?
		}
	}
}