using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.NPCs
{
	// Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
	public class Skinwalker : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("SkinWalker");
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Zombie];
		}

		public override void SetDefaults() {
			NPC.width = 34;
			NPC.height = 46;
			NPC.damage = 140;
			NPC.defense = 6;
			NPC.lifeMax = 4000;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = 60f;
			NPC.knockBackResist = 0.5f;
			NPC.aiStyle = 3;
			AIType = NPCID.Zombie;
			AnimationType = NPCID.Zombie;
		}

        public int npcType = 10;

        //public override void OnHitPlayer(Player player, int damage, bool crit)
    }
}