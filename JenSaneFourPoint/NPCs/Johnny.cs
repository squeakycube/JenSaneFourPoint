using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace JenSaneFourPoint.NPCs
{
	// Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
	public class Johnny : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Johnny");
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Guide];
		}

		public override void SetDefaults() {
			NPC.width = 18;
			NPC.height = 40;
			NPC.damage = 240;
			NPC.defense = 6;
			NPC.lifeMax = 1000;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = 60f;
			NPC.knockBackResist = 0.5f;
			NPC.aiStyle = 3;
			AIType = NPCID.Zombie;
			AnimationType = NPCID.Guide;
			//banner = Item.NPCtoBanner(NPCID.Zombie);
			//bannerItem = Item.BannerToItem(banner);
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (NPC.downedMechBossAny)
            {
                return SpawnCondition.OverworldNightMonster.Chance * 0.02f; // Spawn with 1/5th the chance of a regular zombie.
            }
            else
            {
                return 0.0f;
            }
        }

        public override void OnHitPlayer(Player player, int damage, bool crit)
        {
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    // Because we want to spawn minions, and minions are NPCs, we have to do this on the server (or singleplayer, "!= NetmodeID.MultiplayerClient" covers both)
                    // This means we also have to sync it after we spawned and set up the minion
                    return;
                }
                var entitySource = NPC.GetSource_FromAI();

            //   for (int i = 0; i < count; i++)
            //  {
            int index = NPC.NewNPC(entitySource, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<Skinwalker>(), NPC.whoAmI);
                    NPC minionNPC = Main.npc[index];

            //NPC.life <= 0

            // Now that the minion is spawned, we need to prepare it with data that is necessary for it to work
            // This is not required usually if you simply spawn NPCs, but because the minion is tied to the body, we need to pass this information to it

            // Finally, syncing, only sync on server and if the NPC actually exists (Main.maxNPCs is the index of a dummy NPC, there is no point syncing it)
            if (Main.netMode == NetmodeID.Server && index < Main.maxNPCs)
            {
                NetMessage.SendData(MessageID.SyncNPC, number: index);
            }
        }
    }
}