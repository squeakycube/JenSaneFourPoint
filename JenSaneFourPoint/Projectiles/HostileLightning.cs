using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Projectiles
{
	public class HostileLightning : ModProjectile
	{
        public override string Texture => "Terraria/Images/Projectile_466";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lightning Arc");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 20;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 1;
        }

        float colorlerp;
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.scale = 0.65f;
            Projectile.aiStyle = -1;
            Projectile.hostile = true;
            Projectile.alpha = 100;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 120;
            Projectile.penetrate = -1;
            CooldownSlot = 1;
        }

        Color DrawColor = Color.Cyan;

        public override void AI()
        {
            if (Projectile.localAI[1] == 100)
                DrawColor = new Color(231, 174, 254);

            int shadertype = (int)Projectile.localAI[1];
            Lighting.AddLight(Projectile.Center, DrawColor.A / 255, DrawColor.G / 255, DrawColor.G / 255);
            colorlerp += 0.15f;
            Projectile.localAI[0]++;

            if (Main.rand.NextBool(6))
            {
                if (Main.rand.Next(Projectile.extraUpdates) != 0)
                    return;
                for (int index1 = 0; index1 < 2; ++index1)
                {
                    float num1 = Projectile.rotation + (float)((Main.rand.Next(2) == 1 ? -1.0 : 1.0) * 1.57079637050629);
                    float num2 = (float)(Main.rand.NextDouble() * 0.800000011920929 + 1.0);
                    Vector2 vector2 = new Vector2((float)Math.Cos((double)num1) * num2, (float)Math.Sin((double)num1) * num2);
                    int index2 = Dust.NewDust(Projectile.Center, 0, 0, 226, vector2.X, vector2.Y, 0, DrawColor, 1f);
                    Main.dust[index2].noGravity = true;
                    Main.dust[index2].scale = 1.2f;
                    Main.dust[index2].shader = GameShaders.Armor.GetSecondaryShader(shadertype, Main.LocalPlayer);
                }
                if (Main.rand.Next(5) != 0)
                    return;
                int index3 = Dust.NewDust(Projectile.Center + Projectile.velocity.RotatedBy(1.57079637050629, new Vector2()) * ((float)Main.rand.NextDouble() - 0.5f) * (float)Projectile.width - Vector2.One * 4f, 8, 8, 31, 0.0f, 0.0f, 100, DrawColor, 1.5f);
                Dust dust = Main.dust[index3];
                dust.shader = GameShaders.Armor.GetSecondaryShader(shadertype, Main.LocalPlayer);
                dust.velocity = dust.velocity * 0.5f;
                Main.dust[index3].velocity.Y = -Math.Abs(Main.dust[index3].velocity.Y);
            }

            float num3 = Projectile.velocity.Length(); //take length of initial velocity
            Vector2 spinningpoint = Vector2.UnitX.RotatedBy(Projectile.ai[0]) * num3; //create a base velocity to modify for actual velocity of projectile
            Vector2 rotationVector2 = spinningpoint.RotatedBy(Projectile.ai[1] * (Math.Floor(Math.Sin((Projectile.localAI[0] - MathHelper.Pi / 4) * 2)) + 0.5f) * MathHelper.Pi / 4); //math thing for zigzag pattern
            Projectile.velocity = rotationVector2;
            Projectile.rotation = Projectile.velocity.ToRotation() + 1.570796f;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            for (int index = 0; index < Projectile.oldPos.Length && ((double)Projectile.oldPos[index].X != 0.0 || (double)Projectile.oldPos[index].Y != 0.0); ++index)
            {
                Rectangle myRect = projHitbox;
                myRect.X = (int)Projectile.oldPos[index].X;
                myRect.Y = (int)Projectile.oldPos[index].Y;
                if (myRect.Intersects(targetHitbox))
                    return true;
            }
            return false;
        }

        public override void Kill(int timeLeft)
        {
            int shadertype = (DrawColor == new Color(231, 174, 254)) ? 100 : 0;
            float num2 = (float)(Projectile.rotation + 1.57079637050629 + (Main.rand.Next(2) == 1 ? -1.0 : 1.0) * 1.57079637050629);
            float num3 = (float)(Main.rand.NextDouble() * 2.0 + 2.0);
            Vector2 vector2 = new Vector2((float)Math.Cos(num2) * num3, (float)Math.Sin(num2) * num3);
            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                int index = Dust.NewDust(Projectile.oldPos[i], 0, 0, 229, vector2.X, vector2.Y, 0, DrawColor, 1f);
                Main.dust[index].noGravity = true;
                Main.dust[index].scale = 1.7f;
                Main.dust[index].shader = GameShaders.Armor.GetSecondaryShader(shadertype, Main.LocalPlayer);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Electrified, 180);
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Electrified, 120);
        }

        public override Color? GetAlpha(Color lightColor)
        {

            return Color.Lerp(Color.White, DrawColor, 0.66f + (float)Math.Sin(colorlerp) / 3);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture2D13 = Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value;
            Rectangle rectangle = texture2D13.Bounds;
            Vector2 origin2 = rectangle.Size() / 2f;
            Color color27 = Color.Lerp(Projectile.GetAlpha(lightColor), Color.Black, 0.4f);
            for (int i = 1; i < ProjectileID.Sets.TrailCacheLength[Projectile.type]; i++)
            {
                if (Projectile.oldPos[i] == Vector2.Zero || Projectile.oldPos[i - 1] == Projectile.oldPos[i])
                    continue;
                Vector2 offset = Projectile.oldPos[i - 1] - Projectile.oldPos[i];
                int length = (int)offset.Length();
                float scale = Projectile.scale * (float)Math.Sin((i * 0.5f) / MathHelper.Pi);
                offset.Normalize();
                const int step = 3;
                for (int j = 0; j < length; j += step)
                {
                    Vector2 value5 = Projectile.oldPos[i] + offset * j;
                    Main.EntitySpriteDraw(texture2D13, value5 + Projectile.Size / 2f - Main.screenPosition + new Vector2(0, Projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color27, Projectile.rotation, origin2, scale + 0.15f, SpriteEffects.FlipHorizontally, 0);
                }
            }
            //Main.EntitySpriteDraw(texture2D13, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), Projectile.GetAlpha(lightColor), Projectile.rotation, origin2, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }

        public override void PostDraw(Color lightColor)
        {
            Texture2D texture2D13 = Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value;
            Rectangle rectangle = texture2D13.Bounds;
            Vector2 origin2 = rectangle.Size() / 2f;
            Color color27 = Projectile.GetAlpha(lightColor);
            for (int i = 1; i < ProjectileID.Sets.TrailCacheLength[Projectile.type]; i++)
            {
                if (Projectile.oldPos[i] == Vector2.Zero || Projectile.oldPos[i - 1] == Projectile.oldPos[i])
                    continue;
                Vector2 offset = Projectile.oldPos[i - 1] - Projectile.oldPos[i];
                int length = (int)offset.Length();
                float scale = Projectile.scale * (float)Math.Sin((i * 0.5f) / MathHelper.Pi);
                offset.Normalize();
                const int step = 3;
                for (int j = 0; j < length; j += step)
                {
                    Vector2 value5 = Projectile.oldPos[i] + offset * j;
                    Main.EntitySpriteDraw(texture2D13, value5 + Projectile.Size / 2f - Main.screenPosition + new Vector2(0, Projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color27, Projectile.rotation, origin2, scale, SpriteEffects.FlipHorizontally, 0);
                }
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.velocity = Vector2.Zero;
            return false;
        }
    }
}