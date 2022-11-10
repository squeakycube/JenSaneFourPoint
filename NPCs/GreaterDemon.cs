using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using JenSaneFourPoint.Items;
using Terraria.ModLoader.Utilities;
//using JennysInsanity.Items.Weapons;

namespace JenSaneFourPoint.NPCs
{
    [AutoloadHead] //I need to fix the head showing on the map later
    // Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
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
			//npc.lifeMax = 20;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = 60f;
			NPC.knockBackResist = 0.75f;
			NPC.aiStyle = 14;
			AIType = NPCID.Demon;
            //AnimationType = NPCID.Demon;
            AnimationType = 2;
			NPC.boss = true;
			NPC.lavaImmune = true;
			//NPC.noTileCollide = true;
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
			
		//	if(Main.hardMode == true)
		//	{
			//return SpawnCondition.ZoneUnderworldHeight.Chance * 0.75f;
			//return SpawnCondition.OceanMonster.Chance * 0.5f : 0f;
			if(Main.hardMode)
			return SpawnCondition.Underworld.Chance * 0.005f;
			return SpawnCondition.SolarEclipse.Chance * 0.001f; // Remember to test this value for balance
		}

			/*	public override void OnKill() {
				//	npcLoot.Add(ItemDropRule.Common(ItemID.Shackle, 50));
				//Item.NewItem(npc.getRect(), ModContent.ItemType<MoltenTrident>());
				/////////////////////Item.NewItem(npc.getRect(), ModContent.ItemType<MoltenTrident>());
										int choice = Main.rand.Next(10);
			int item = 0;
			switch (choice) {
				case 0:
					item = ModContent.ItemType<MoltenTrident>();
					break;
				case 1:
					item = ModContent.ItemType<KOBat>();
					break;
				case 2:
					item = ModContent.ItemType<SatanistBook>();
					break;
			}
			if (item > 0) {
				Item.NewItem(NPC.getRect(), item);
			}
			if (Main.expertMode) {
				NPC.DropBossBags();
			}
			else {
				choice = Main.rand.Next(7);
				if (choice == 0) {
					Item.NewItem(NPC.getRect(), ModContent.ItemType<MoltenTrident>());
				}
				else if (choice == 1) {
					Item.NewItem(NPC.getRect(), ModContent.ItemType<KOBat>());
				}
				if (choice != 1) {
					Item.NewItem(NPC.getRect(), ItemID.Bunny);
				}
				Item.NewItem(NPC.getRect(), ModContent.ItemType<Items.SatanistBook>());
			}
		}*/
					
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