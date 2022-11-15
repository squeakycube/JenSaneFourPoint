using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Items.Pets
{
    public class PupuyoukaiProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 13;
            Main.projPet[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.BabyDino); // Copy the stats of the Zephyr Fish

            AIType = ProjectileID.BabyDino; // Copy the AI of the Zephyr Fish.
        }

        public override bool PreAI()
        {
            Player player = Main.player[Projectile.owner];

            player.zephyrfish = false; // Relic from aiType

            return true;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            // Keep the projectile from disappearing as long as the player isn't dead and has the pet buff.
            if (!player.dead && player.HasBuff(ModContent.BuffType<Pupuyoukai>()))
            {
                Projectile.timeLeft = 2;
            }
        }
    }
}