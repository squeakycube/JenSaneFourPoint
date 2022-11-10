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

		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return SpawnCondition.OverworldNightMonster.Chance * 0.005f;
			//return SpawnCondition.Overworld
		}

        public override void OnHitPlayer(Player player, int damage, bool crit)
        {
            {
                player.AddBuff(BuffID.Bleeding, 2400, true);
                NPC.SpawnOnPlayer(player.whoAmI, Mod.Find<ModNPC>("SkinWalker").Type); //This SHOULD spawn a skin walker on the player but spawns it a far distance away for some reason where it bugs out and despawns
                NPC.life = 0;
            }
        }

        //  public override void NPCLoot()
        //   {
        //      {
        //NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Thomas"));
        //       }
        //    }

    }
}