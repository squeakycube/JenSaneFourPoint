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
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (NPC.downedMechBossAny)
            {
                return SpawnCondition.OverworldNightMonster.Chance * 0.2f; // Spawn with 1/5th the chance of a regular zombie.
            }
            else
            {
                return 0.0f;
            }
        }

        public override void OnHitPlayer(Player player, int damage, bool crit)
        {
                player.AddBuff(BuffID.Bleeding, 2400, true);
        }


        public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("CrowSkull").Type, 5));
            npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("ExampleWings").Type, 500));
            npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("PupuyoukaiSummon").Type, 50));
        }
    }
}