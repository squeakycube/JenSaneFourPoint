using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using JenSaneFourPoint.Items;
using Terraria.ModLoader.Utilities;
//using JennysInsanity.Items.Weapons;

namespace JenSaneFourPoint.NPCs
{
    [AutoloadHead] //I need to fix the head showing on the map later
    public class GreaterDemon : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Greater Demon");
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[2];
		}

		public override void SetDefaults() {
			NPC.width = 72;
			NPC.height = 56;
			NPC.damage = 90;
			NPC.defense = 12;
			NPC.lifeMax = 20000;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = 60f;
			NPC.knockBackResist = 0.75f;
			NPC.aiStyle = 14;
			AIType = NPCID.Demon;
            AnimationType = 2;
			NPC.boss = true;
			NPC.lavaImmune = true;
		}

        private bool startDespawning;

        public void PreAi()
        {
            if (!startDespawning)
            {
                startDespawning = true;

                // Despawn after 90 ticks (1.5 seconds) if the NPC gets far enough away
                NPC.timeLeft = 90;
            }
        }

        public override void AI()
        {
            if (NPC.target < 0 || NPC.target == 255)
            {
                NPC.TargetClosest(false);
                NPC.direction = 1;
                NPC.velocity.Y = NPC.velocity.Y - 0.1f;
                if(NPC.timeLeft > 20)
                {
                    NPC.timeLeft = 20;
                    return;
                }
            }
        }

public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if(Main.hardMode)
			return SpawnCondition.Underworld.Chance * 0.005f;
			return SpawnCondition.SolarEclipse.Chance * 0.001f;
		}
        
					
					public void Update(NPC npc, ref int buffIndex)
{
npc.velocity = npc.velocity*(3.88f);
}

public float Timer {
	get => NPC.ai[0];
	set => NPC.ai[0] = value;
}
}
}