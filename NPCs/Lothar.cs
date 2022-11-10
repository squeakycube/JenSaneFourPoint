using JenSaneFourPoint.Items;
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using Terraria.DataStructures;

namespace JenSaneFourPoint.NPCs
{
    // [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
    [AutoloadHead]
    public class Lothar : ModNPC
    {
        public override string Texture => "JenSaneFourPoint/NPCs/Lothar";
        public override void SetStaticDefaults()
        {
            // DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
            // DisplayName.SetDefault("Example Person");
            Main.npcFrameCount[Type] = 16; // The amount of frames the NPC has

         //   NPCID.Sets.ExtraFramesCount[Type] = 0; // Generally for Town NPCs, but this is how the NPC does extra things such as sitting in a chair and talking to other NPCs.
          //  NPCID.Sets.AttackFrameCount[Type] = 4;
            NPCID.Sets.DangerDetectRange[Type] = 700; // The amount of pixels away from the center of the npc that it tries to attack enemies.
            NPCID.Sets.AttackType[Type] = 0;
            NPCID.Sets.AttackTime[Type] = 90; // The amount of time it takes for the NPC's attack animation to be over once it starts.
            NPCID.Sets.AttackAverageChance[Type] = 30;
            NPCID.Sets.HatOffsetY[Type] = 4; // For when a party is active, the party hat spawns at a Y offset.

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f, // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
                Direction = 1 // -1 is left and 1 is right. NPCs are drawn facing the left by default but ExamplePerson will be drawn facing the right
                              // Rotation = MathHelper.ToRadians(180) // You can also change the rotation of an NPC. Rotation is measured in radians
                              // If you want to see an example of manually modifying these when the NPC is drawn, see PreDraw
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            // Set Example Person's biome and neighbor preferences with the NPCHappiness hook. You can add happiness text and remarks with localization (See an example in ExampleMod/Localization/en-US.lang).
            // NOTE: The following code uses chaining - a style that works due to the fact that the SetXAffection methods return the same NPCHappiness instance they're called on.
            NPC.Happiness
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Like) // Example Person prefers the forest.
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike) // Example Person dislikes the snow.
                //.SetBiomeAffection<ExampleSurfaceBiome>(AffectionLevel.Love) // Example Person likes the Example Surface Biome
                .SetNPCAffection(NPCID.Dryad, AffectionLevel.Love) // Loves living near the dryad.
                .SetNPCAffection(NPCID.Guide, AffectionLevel.Like) // Likes living near the guide.
                .SetNPCAffection(NPCID.Merchant, AffectionLevel.Dislike) // Dislikes living near the merchant.
                .SetNPCAffection(NPCID.Demolitionist, AffectionLevel.Hate) // Hates living near the demolitionist.
            ; // < Mind the semicolon!
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true; // Sets NPC to be a Town NPC
            NPC.friendly = true; // NPC Will not attack player
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 5;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;

            AnimationType = NPCID.Guide;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the preferred biomes of this town NPC listed in the bestiary.
				// With Town NPCs, you usually set this to what biome it likes the most in regards to NPC happiness.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,

				// Sets your NPC's flavor text in the bestiary.
				new FlavorTextBestiaryInfoElement("Hailing from a mysterious world, Lothar is here to reshape this town into his own image."),

				// You can add multiple elements if you really wanted to
				// You can also use localization keys (see Localization/en-US.lang)
				new FlavorTextBestiaryInfoElement("JenSaneFourPoint.Bestiary.Lothar")
            });
        }

        // The PreDraw hook is useful for drawing things before our sprite is drawn or running code before the sprite is drawn
        // Returning false will allow you to manually draw your NPC
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            // This code slowly rotates the NPC in the bestiary
            // (simply checking NPC.IsABestiaryIconDummy and incrementing NPC.Rotation won't work here as it gets overridden by drawModifiers.Rotation each tick)
            if (NPCID.Sets.NPCBestiaryDrawOffset.TryGetValue(Type, out NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers))
            {
                drawModifiers.Rotation += 0.001f;

                // Replace the existing NPCBestiaryDrawModifiers with our new one with an adjusted rotation
                NPCID.Sets.NPCBestiaryDrawOffset.Remove(Type);
                NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
            }

            return true;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        { // Requirements for the town NPC to spawn.
            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (!player.active)
                {
                    continue;
                }

                // Player has to have either an ExampleItem or an ExampleBlock in order for the NPC to spawn
               // if (player.inventory.Any(item => item.type == ModContent.ItemType<ExampleItem>() || item.type == ModContent.ItemType<Items.Placeable.ExampleBlock>()))
                    if (Main.hardMode)
                {
                    if (player.inventory.Any(item => item.type == ModContent.ItemType<TheMilkGodBlood>()))
                        {
                        return true;
                    }
                }
            }

            return false;
        }

        // Example Person needs a house built out of ExampleMod tiles. You can delete this whole method in your townNPC for the regular house conditions.
        public override bool CheckConditions(int left, int right, int top, int bottom)
        {
            int score = 0;
            for (int x = left; x <= right; x++)
            {
                for (int y = top; y <= bottom; y++)
                {
                    int type = Main.tile[x, y].TileType;
                }
            }

            return score >= ((right - left) * (bottom - top)) / 2;
        }

        public string TownNPCName()
        {
            switch (WorldGen.genRand.Next(4))

            {
                case 0: // The cases are potential names for the NPC.
                    return "Lothar killer of Philbert";

                case 1:
                    return "Lothar the Traitor";

                case 2:
                    return "Lothar";

                case 3:
                    return "Lothar the Mastermind";

                case 4:
                    return "Lothar the Goblin";

                default:
                    return "Lothar";

                //default:
               //     return "Lothar";
            }
        }

        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();

                       // These are things that the NPC has a chance of telling you when you talk to it.
            chat.Add("Sometimes I miss Roddrick and Philbert fighting.");
            chat.Add("I still have night terrors of what Sam did to me. *shutters*.");
            chat.Add("Why does lorely have so many heads?");
            chat.Add("Impressive what a little of Artemis' engineering can do?");
            chat.Add("I dont think Persona trusts me, she just...stares?");
            chat.Add("Why does Toytork swear so much?");
            chat.Add("I'm not sure how to feel about Vanguard?");
            chat.Add("I admire Varzek's vast intelligence.");
            chat.Add("Osariu was a failed experiment and I need to try again with Toytork.");
            chat.Add("I dont consider Ludhaven a threat due to his antics.");
            chat.Add("Say hi to Dimitri for me *laughs*.");
            // chat.Add("This message has a weight of 5, meaning it appears 5 times more often.", 5.0);
            chat.Add("The milk god's blood is great for fighters such as yourself.", 2.0);
            chat.Add("I have always wanted to try a teleportation mirror but finding a magic mirror and 30 teleportation potions is to much for me.", 2.0);
            chat.Add("*goblin noises*", 0.5);
            chat.Add("*enters goblin mode*", 0.5);
            chat.Add("Make Epilia great again!", 0.7);
            //chat.Add($"I upgraded your {(GetKillCount)} to a", 0.5);
            // chat.Add(Get KillCount, 10.0);            //$"I upgraded your {Lang.GetItemNameValue(ItemID.HiveBackpack)} to a {Lang.GetItemNameValue(ModContent.ItemType<WaspNest>())}";
            //chat.Add($"I upgraded your {GetKillCount}", 10.0));
            return chat; // chat is implicitly cast to a string.             Console.WriteLine("Counter SomeClass: " + Globals.counter);
           // chat.Add($"Globals.KillCount", 10.0);
        }

        public override void SetChatButtons(ref string button, ref string button2)
        { // What the chat buttons are when you open up the chat UI
            button = Language.GetTextValue("LegacyInterface.28");
         //   button2 = "Awesomeify";
            if (Main.LocalPlayer.HasItem(ItemID.HiveBackpack))
            {
                button = "Upgrade " + Lang.GetItemNameValue(ItemID.HiveBackpack);
            }
        }


        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                // We want 3 different functionalities for chat buttons, so we use HasItem to change button 1 between a shop and upgrade action.

                //Main.npcChatText = $"I upgraded your {(GetKillCount)} to a";

                if (Main.LocalPlayer.HasItem(ItemID.HiveBackpack))
                {
                    SoundEngine.PlaySound(SoundID.Item37); // Reforge/Anvil sound

                    Main.npcChatText = $"I upgraded your {Lang.GetItemNameValue(ItemID.HiveBackpack)} to a {Lang.GetItemNameValue(ModContent.ItemType<WaspNest>())}";

                    int hiveBackpackItemIndex = Main.LocalPlayer.FindItem(ItemID.HiveBackpack);
                    var entitySource = NPC.GetSource_GiftOrReward();

                    Main.LocalPlayer.inventory[hiveBackpackItemIndex].TurnToAir();
                    Main.LocalPlayer.QuickSpawnItem(entitySource, ModContent.ItemType<StardustTrident>());

                    return;
                }

                shop = true;
            }
        }



        // Not completely finished, but below is what the NPC will sell

        public override void SetupShop(Chest shop, ref int nextSlot) {
           // shop.item[nextSlot++].SetDefaults(ItemType<TheMilkGodBlood>());
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<MoltenTrident>());
            nextSlot++;
            // shop.item[nextSlot].SetDefaults(ItemType<EquipMaterial>());
            // nextSlot++;
            // shop.item[nextSlot].SetDefaults(ItemType<BossItem>());
            // nextSlot++;
            //  shop.item[nextSlot++].SetDefaults(ItemType<Items.Placeable.Furniture.ExampleWorkbench>());
            //  shop.item[nextSlot++].SetDefaults(ItemType<Items.Placeable.Furniture.ExampleChair>());
            //  shop.item[nextSlot++].SetDefaults(ItemType<Items.Placeable.Furniture.ExampleDoor>());
            //  shop.item[nextSlot++].SetDefaults(ItemType<Items.Placeable.Furniture.ExampleBed>());
            //  shop.item[nextSlot++].SetDefaults(ItemType<Items.Placeable.Furniture.ExampleChest>());
            //shop.item[nextSlot++].SetDefaults(ItemType<ExamplePickaxe>());
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<TheMilkGodBlood>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<BootsOfSilver>());
            nextSlot++;
            //            recipe.AddIngredient(Mod, "RavenSkull", 5);
        }

        // 	if (Main.LocalPlayer.HasBuff(BuffID.Lifeforce)) {
        // 		shop.item[nextSlot++].SetDefaults(ItemType<ExampleHealingPotion>());
        // 	}
        //
        // 	// if (Main.LocalPlayer.GetModPlayer<ExamplePlayer>().ZoneExample && !GetInstance<ExampleConfigServer>().DisableExampleWings) {
        // 	// 	shop.item[nextSlot].SetDefaults(ItemType<ExampleWings>());
        // 	// 	nextSlot++;
        // 	// }
        //
        // 	if (Main.moonPhase < 2) {
        // 		shop.item[nextSlot++].SetDefaults(ItemType<ExampleSword>());
        // 	}
        // 	else if (Main.moonPhase < 4) {
        // 		// shop.item[nextSlot++].SetDefaults(ItemType<ExampleGun>());
        // 		shop.item[nextSlot].SetDefaults(ItemType<ExampleBullet>());
        // 	}
        // 	else if (Main.moonPhase < 6) {
        // 		// shop.item[nextSlot++].SetDefaults(ItemType<ExampleStaff>());
        // 	}
        //
        // 	// todo: Here is an example of how your npc can sell items from other mods.
        // 	// var modSummonersAssociation = ModLoader.TryGetMod("SummonersAssociation");
        // 	// if (ModLoader.TryGetMod("SummonersAssociation", out Mod modSummonersAssociation)) {
        // 	// 	shop.item[nextSlot].SetDefaults(modSummonersAssociation.ItemType("BloodTalisman"));
        // 	// 	nextSlot++;
        // 	// }
        //
        // 	// if (!Main.LocalPlayer.GetModPlayer<ExamplePlayer>().examplePersonGiftReceived && GetInstance<ExampleConfigServer>().ExamplePersonFreeGiftList != null) {
        // 	// 	foreach (var item in GetInstance<ExampleConfigServer>().ExamplePersonFreeGiftList) {
        // 	// 		if (Item.IsUnloaded) continue;
        // 	// 		shop.item[nextSlot].SetDefaults(Item.Type);
        // 	// 		shop.item[nextSlot].shopCustomPrice = 0;
        // 	// 		shop.item[nextSlot].GetGlobalItem<ExampleInstancedGlobalItem>().examplePersonFreeGift = true;
        // 	// 		nextSlot++;
        // 	// 		//TODO: Have tModLoader handle index issues.
        // 	// 	}
        // 	// }
        // }
    }
}