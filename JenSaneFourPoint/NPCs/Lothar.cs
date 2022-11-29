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
    [AutoloadHead]
    public class Lothar : ModNPC
    {
        public override string Texture => "JenSaneFourPoint/NPCs/Lothar";
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 16; 
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

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (!player.active)
                {
                    continue;
                }
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
            chat.Add("The milk god's blood is great for fighters such as yourself.", 2.0);
            chat.Add("I have always wanted to try a teleportation mirror but finding a magic mirror and 30 teleportation potions is to much for me.", 2.0);
            chat.Add("*goblin noises*", 0.5);
            chat.Add("*enters goblin mode*", 0.5);
            chat.Add("Make Epilia great again!", 0.7);
            return chat;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        { // What the chat buttons are when you open up the chat UI
            button = Language.GetTextValue("LegacyInterface.28");
            if (Main.LocalPlayer.HasItem(ItemID.HiveBackpack))
            {
                button = "Upgrade " + Lang.GetItemNameValue(ItemID.LunarBar);
            }
        }


        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                if (Main.LocalPlayer.HasItem(ItemID.LunarBar))
                {
                    SoundEngine.PlaySound(SoundID.Item37); // Reforge/Anvil sound

                    Main.npcChatText = $"I upgraded your {Lang.GetItemNameValue(ItemID.LunarBar)} to a {Lang.GetItemNameValue(ModContent.ItemType<MoltenTrident>())}";

                    int hiveBackpackItemIndex = Main.LocalPlayer.FindItem(ItemID.LunarBar);
                    var entitySource = NPC.GetSource_GiftOrReward();

                    Main.LocalPlayer.inventory[hiveBackpackItemIndex].TurnToAir();
                    Main.LocalPlayer.QuickSpawnItem(entitySource, ModContent.ItemType<StardustTrident>());

                    return;
                }

                shop = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot) {
           // shop.item[nextSlot++].SetDefaults(ItemType<TheMilkGodBlood>());
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<MoltenTrident>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<TheMilkGodBlood>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<BootsOfSilver>());
            nextSlot++;
        }
    }
}