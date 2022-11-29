using JenSaneFourPoint.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria;
using Terraria.Chat;
using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;

namespace JenSaneFourPoint.NPCs //PlagueDoctor
{
    [AutoloadHead]
    class PlagueDoctor : ModNPC //
    {
        public const double despawnTime = 48600.0;

        public static double spawnTime = double.MaxValue;

        public List<Item> shopItems = new List<Item>();

        public override bool PreAI()
        {
            if ((!Main.dayTime || Main.time >= despawnTime) && !IsNpcOnscreen(NPC.Center)) // If it's past the despawn time and the NPC isn't onscreen
            {
                if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText(Language.GetTextValue("LegacyMisc.35", NPC.FullName), 50, 125, 255);
                else ChatHelper.BroadcastChatMessage(NetworkText.FromKey("LegacyMisc.35", NPC.GetFullNetName()), new Color(50, 125, 255));
                NPC.active = false;
                NPC.netSkip = -1;
                NPC.life = 0;
                return false;
            }

            return true;
        }

        public static void UpdateTravelingMerchant()
        {
            bool travelerIsThere = (NPC.FindFirstNPC(ModContent.NPCType<PlagueDoctor>()) != -1);
            if (Main.dayTime && Main.time == 0)
            {
                if (!travelerIsThere && Main.rand.NextBool(3))
                {
                    spawnTime = GetRandomSpawnTime(5400, 8100); // minTime = 6:00am, maxTime = 7:30am
                }
                else
                {
                    spawnTime = double.MaxValue; // no spawn today
                }
            }

            if (!travelerIsThere && CanSpawnNow())
            {
                int newTraveler = NPC.NewNPC(Terraria.Entity.GetSource_TownSpawn(), Main.spawnTileX * 16, Main.spawnTileY * 16, ModContent.NPCType<PlagueDoctor>(), 1); // Spawning at the world spawn
                NPC traveler = Main.npc[newTraveler];
                traveler.homeless = true;
                traveler.direction = Main.spawnTileX >= WorldGen.bestX ? -1 : 1;
                traveler.netUpdate = true;

                // Prevents the traveler from spawning again the same day
                spawnTime = double.MaxValue;

                // Annouce that the traveler has spawned in!
                if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText(Language.GetTextValue("Announcement.HasArrived", traveler.FullName), 50, 125, 255);
                else ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Announcement.HasArrived", traveler.GetFullNetName()), new Color(50, 125, 255));
            }
        }

        private static bool CanSpawnNow()
        {
            // can't spawn if any events are running
            if (Main.eclipse || Main.invasionType > 0 && Main.invasionDelay == 0 && Main.invasionSize > 0)
                return false;

            // can't spawn if the sundial is active
            if (Main.fastForwardTime)
                return false;

            // can spawn if daytime, and between the spawn and despawn times
            return Main.dayTime && Main.time >= spawnTime && Main.time < despawnTime;
        }

        private static bool IsNpcOnscreen(Vector2 center)
        {
            int w = NPC.sWidth + NPC.safeRangeX * 2;
            int h = NPC.sHeight + NPC.safeRangeY * 2;
            Rectangle npcScreenRect = new Rectangle((int)center.X - w / 2, (int)center.Y - h / 2, w, h);
            foreach (Player player in Main.player)
            {
                // If any player is close enough to the traveling merchant, it will prevent the npc from despawning
                if (player.active && player.getRect().Intersects(npcScreenRect)) return true;
            }
            return false;
        }

        public static double GetRandomSpawnTime(double minTime, double maxTime)
        {
            // A simple formula to get a random time between two chosen times
            return (maxTime - minTime) * Main.rand.NextDouble() + minTime;
        }

        public void CreateNewShop()
        {
            // create a list of item ids
            var itemIds = new List<int>();

            // For each slot we add a switch case to determine what should go in that slot
            switch (Main.rand.Next(2))
            {
                case 0:
                    itemIds.Add(ModContent.ItemType<VampiricPotion>());
                    break;
                default:
                    itemIds.Add(ModContent.ItemType<VileOfToxin>());
                    break;
            }

            switch (Main.rand.Next(2))
            {
                case 0:
                    itemIds.Add(ModContent.ItemType<PlagueDoctorMedicalSupplies>());
                    break;
                default:
                    itemIds.Add(ModContent.ItemType<PlagueDoctorMedicalSupplies>());
                    break;
            }

            switch (Main.rand.Next(4))
            {
                case 0:
                    itemIds.Add(ModContent.ItemType<VampiricPotion>());
                    break;
                case 1:
                    itemIds.Add(ModContent.ItemType<VileOfToxin>());
                    break;
                case 2:
                    itemIds.Add(ModContent.ItemType<PotencyRegenerationPotion>());
                    break;
                default:
                    itemIds.Add(ModContent.ItemType<MegaBranch>());
                    break;
            }

            // convert to a list of items
            shopItems = new List<Item>();
            foreach (int itemId in itemIds)
            {
                Item item = new Item();
                item.SetDefaults(itemId);
                shopItems.Add(item);
            }
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 20;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 8;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 90;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = 4;
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Guide;
            TownNPCStayingHomeless = true;
            CreateNewShop();
        }

        public override void SaveData(TagCompound tag)
        {
            tag["itemIds"] = shopItems;
        }

        public override void LoadData(TagCompound tag)
        {
            shopItems = tag.Get<List<Item>>("shopItems");
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            return false; // This should always be false, because we spawn in the Traveling Merchant manually
        }

        public override ITownNPCProfile TownNPCProfile()
        {
            return new PlagueDoctorProfile();
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>() {
                "Toytork",
                "John",
                "Plague Doctor",
                "Doctor"
            };
        }

        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();


            chat.Add("Need me to sew up another body?");
            chat.Add("I have been looking for a student recently.");
            chat.Add("*cough cough*...it's not the plague.....I swear");

            return chat;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            foreach (Item item in shopItems)
            {
                // We don't want "empty" items and unloaded items to appear
                if (item == null || item.type == ItemID.None)
                    continue;

                shop.item[nextSlot].SetDefaults(item.type);
                nextSlot++;
            }
        }

        public override void AI()
        {
            NPC.homeless = true; // Make sure it stays homeless
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ExampleCostume>()));
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 30;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            //   projType = ModContent.ProjectileType<WoodenA>();
            projType = ProjectileID.WoodenArrowFriendly; //ProjectileID.FireArrow
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }
    }

    public class PlagueDoctorProfile : ITownNPCProfile
    {
        public int RollVariation() => 0;
        public string GetNameForVariant(NPC npc) => npc.getNewNPCName();

        public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc)
        {
            if (npc.IsABestiaryIconDummy && !npc.ForcePartyHatOn)
                return ModContent.Request<Texture2D>("JenSaneFourPoint/NPCs/PlagueDoctor");

            if (npc.altTexture == 1)
                return ModContent.Request<Texture2D>("JenSaneFourPoint/NPCs/PlagueDoctor");

            return ModContent.Request<Texture2D>("JenSaneFourPoint/NPCs/PlagueDoctor");
        }

        public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("JenSaneFourPoint/NPCs/PlagueDoctor_Head");
    }
}