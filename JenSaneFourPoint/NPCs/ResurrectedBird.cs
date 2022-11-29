using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;


namespace JenSaneFourPoint.NPCs
{
	// Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
	public class ResurrectedBird : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("ResurrectedBird");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[4];
        }

		public override void SetDefaults() {
            NPC.width = 38;
            NPC.height = 38;
            NPC.damage = 45;
			NPC.defense = 6;
			NPC.lifeMax = 2000;
			NPC.HitSound = SoundID.NPCHit28;
			NPC.DeathSound = SoundID.NPCDeath31;
			NPC.value = 60f;
			NPC.knockBackResist = 0.5f;
			NPC.aiStyle = 17;
			AIType = NPCID.Vulture;
			AnimationType = NPCID.Vulture;
		}

        public override void AI()
        {
            if (Math.Abs(NPC.velocity.X) > 0)
            {
                NPC.velocity += new Vector2(NPC.direction * 1.05f, 0);
            }

            if (Math.Abs(NPC.velocity.Y) > 0)
            {
                NPC.velocity += new Vector2(NPC.direction * 1.05f, 0);
            }
        }

            //MoveSpeed = 1000f;











        }
    }