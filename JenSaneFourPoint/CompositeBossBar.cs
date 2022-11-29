using JenSaneFourPoint.NPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Linq;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.UI.BigProgressBar;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ReLogic.Content;

namespace JenSaneFourPoint
{
    public class CompositeBossBar : ModBossBar
    {
        public override Asset<Texture2D> GetIconTexture(ref Rectangle? iconFrame)
        {
            // return TextureAssets.NpcHead[36];
            return TextureAssets.NpcHeadBoss[19];
        }

        public override bool PreDraw(SpriteBatch spriteBatch, NPC npc, ref BossBarDrawParams drawParams)
        {
            // Make the bar shake the less health the NPC has
            float shakeIntensity = Utils.Clamp(1f - drawParams.LifePercentToShow - 0.2f, 0f, 1f);
            drawParams.BarCenter.Y -= 20f;
            drawParams.BarCenter += new Vector2(Main.rand.NextFloat(-1f, 1f), Main.rand.NextFloat(-1f, 1f)) * shakeIntensity * 15f;

            drawParams.IconColor = Main.DiscoColor;

            return true;
        }
    }
}