using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using JenSaneFourPoint.NPCs;

namespace JenSaneFourPoint.Projectiles
{
	public class GolemBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Milk Deathray III");
        }

        public override void SetDefaults()
        {
            Projectile.width = 4;
            Projectile.height = 4;
            Projectile.timeLeft = 630;
            Projectile.penetrate = -1;
            Projectile.hostile = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
        }

        public override void AI()
        {
            NPC npc = Main.npc[(int)Projectile.ai[0]];
            if (!npc.active || npc.type != Mod.Find<ModNPC>("Thomas").Type)
            {
                Projectile.Kill();
                return;
            }
            if (Projectile.localAI[0] == 0f)
            {
               
                 //   cooldownSlot = 1;
                Projectile.Name = GetName();
            }
            Projectile.Center = npc.Center;
            Projectile.localAI[0] += 1f;
            float maxTime = Main.expertMode && NPC.downedMoonlord ? 450f : 300f;
            if (Projectile.localAI[0] > maxTime)
            {
                Projectile.damage = 0;
                Projectile.alpha = (int)((Projectile.localAI[0] - maxTime) / 30f);
            }
            if (Projectile.localAI[0] > maxTime + 30f)
            {
                Projectile.Kill();
            }
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {

        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float point = 0f;
            Vector2 endPoint = Main.npc[(int)Projectile.ai[1]].Center;
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Projectile.Center, endPoint, 4f, ref point);
        }

        public string GetName()
        {
            return "Milk Beam";
        }

        public Color GetColor()
        {
            return Color.White;
        }




    }
}