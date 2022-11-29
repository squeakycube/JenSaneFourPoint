using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace JenSaneFourPoint.Projectiles
{
	public class HealProj : ModProjectile
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("How The Fuck Did That Happen? this deals 0 damage"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults() 
		{
			Projectile.aiStyle = 18;
            //projectile.friendly = true;
            Projectile.friendly = false;
            Projectile.penetrate = 3;
			Projectile.damage = -45;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.width = 52;
			Projectile.height = 50;
			Projectile.knockBack = 6;
			Projectile.tileCollide = false;
						Projectile.extraUpdates = 1;            //Set to above 0 if you want the projectile to update multiple time in a frame
			//						Projectile.friendly = true;         //Can the projectile deal damage to enemies?
			Projectile.hostile = true;         //Can the projectile deal damage to the player?
		}

		public override void AI()
		{
			Lighting.AddLight(Projectile.Center, 2.55f, 0.92f, 0.07f);
			
			//projectile.rotation -= 1.57f;
			//projectile.velocity.Y -= 0.785f;

		}

        public void OnHitPlayer(Player player, Player target, int buffIndex)
        {
           target.AddBuff(BuffID.RapidHealing, 600);
           //target.healLife = 100;
           // Player.HealEffect(100);
        }

        public void OnHitNPC(Player player, NPC target, int buffIndex)
        {
            target.AddBuff(BuffID.RapidHealing, 600);
            //target.healLife = 100;
            // Player.HealEffect(100);
        }
    }
}