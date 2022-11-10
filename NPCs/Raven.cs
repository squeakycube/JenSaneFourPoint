using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;

namespace JenSaneFourPoint.NPCs
{
	// Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
	public class Crow : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Crow");
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
			//banner = Item.NPCtoBanner(NPCID.Vulture);
			//bannerItem = Item.BannerToItem(Vulture);
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNightMonster.Chance * 0.2f; // Spawn with 1/5th the chance of a regular zombie.
        }

        public override void OnHitPlayer(Player player, int damage, bool crit)
        {
                player.AddBuff(BuffID.Bleeding, 2400, true);
        }


        public override void ModifyNPCLoot(NPCLoot npcLoot) {
			// Since Party Zombie is essentially just another variation of Zombie, we'd like to mimic the Zombie drops.
			// To do this, we can either (1) copy the drops from the Zombie directly or (2) just recreate the drops in our code.
			// (1) Copying the drops directly means that if Terraria updates and changes the Zombie drops, your ModNPC will also inherit the changes automatically.
			// (2) Recreating the drops can give you more control if desired but requires consulting the wiki, bestiary, or source code and then writing drop code.

			// (1) This example shows copying the drops directly. For consistency and mod compatibility, we suggest using the smallest positive NPCID when dealing with npcs with many variants and shared drop pools.
			//var zombieDropRules = Main.ItemDropsDB.GetRulesForNPCID(NPCID.Zombie, false); // false is important here
			//foreach (var zombieDropRule in zombieDropRules) {
				// In this foreach loop, we simple add each drop to the PartyZombie drop pool. 
			//	npcLoot.Add(zombieDropRule);
			//}

			// (2) This example shows recreating the drops. This code is commented out because we are using the previous method instead.
			// npcLoot.Add(ItemDropRule.Common(ItemID.Shackle, 50)); // Drop shackles with a 1 out of 50 chance.
			// npcLoot.Add(ItemDropRule.Common(ItemID.ZombieArm, 250)); // Drop zombie arm with a 1 out of 250 chance.

			// Finally, we can add additional drops. Many Zombie variants have their own unique drops: https://terraria.fandom.com/wiki/Zombie
			npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("CrowSkull").Type, 5)); // 1% chance to drop Confetti
            npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("ExampleWings").Type, 50)); // 1% chance to drop Confetti
            npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("PupuyoukaiSummon").Type, 500)); // 1% chance to drop Confetti
        }

       /* public override void OnKill()
        {
            if (Main.rand.NextBool(10))
            {
                Item.NewItem(NPC.getRect(), Mod.Find<ModItem>("RavenSkull").Type);
            }
        }*/

        /*public override void HitEffect(int hitDirection, double damage) {
			for (int i = 0; i < 10; i++) {
				int dustType = Main.rand.Next(139, 143);
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}*/
    }
}