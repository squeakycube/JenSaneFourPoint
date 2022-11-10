using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using JenSaneFourPoint.Items;
//using JennysInsanity.Items.Weapons;
//GitHub Test

namespace JenSaneFourPoint.NPCs
{
	// Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
	public class Thomas : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Thomas Lord of Milk");
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Zombie];
		}

		public override void SetDefaults() {
			NPC.width = 283;
			NPC.height = 803;
			NPC.damage = 390;
			NPC.defense = 120;
			NPC.lifeMax = 2000000;
			//npc.lifeMax = 20;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = 60f;
			NPC.knockBackResist = 0.75f;
			NPC.aiStyle = 69;
			AIType = NPCID.DukeFishron;
			//animationType = NPCID.Demon;
			//banner = Item.NPCtoBanner(NPCID.Demon);
			//bannerItem = Item.BannerToItem(banner);
			NPC.boss = true;
			NPC.lavaImmune = true;
			NPC.noTileCollide = true;
		}

		public void CustomBehavior(ref float ai) {
			float distance = NPC.Distance(Main.player[NPC.target].Center);
			if (distance <= 250) {
				NPC.alpha = 100;
				if (distance > 100) {
					// Make the NPC fade out the farther away the NPC is.
					NPC.alpha += (int)(155 * ((distance - 100) / 150));
				}
				return;
			}
			NPC.alpha = 255;
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
		} */
					
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