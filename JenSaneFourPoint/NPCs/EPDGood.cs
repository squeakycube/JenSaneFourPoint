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
    // This ModNPC serves as an example of a completely custom AI.
    public class EPDGood : ModNPC
    {
        // Here we define an enum we will use with the State slot. Using an ai slot as a means to store "state" can simplify things greatly. Think flowchart.
        private enum ActionState
        {
            Asleep,
            Notice,
            Jump,
            Hover,
            Fall
        }

        // Our texture is 36x36 with 2 pixels of padding vertically, so 38 is the vertical spacing.
        // These are for our benefit and the numbers could easily be used directly in the code below, but this is how we keep code organized.
        private enum Frame
        {
            Asleep1,
            Asleep2,
            Notice,
            Falling,
            Flutter1,
            Flutter2,
            Flutter3,
            Flutter4,
            Flutter5,
            Flutter6,
            Flutter7,
            Flutter8,
            Flutter9
        }

        // These are reference properties. One, for example, lets us write AI_State as if it's NPC.ai[0], essentially giving the index zero our own name.
        // Here they help to keep our AI code clear of clutter. Without them, every instance of "AI_State" in the AI code below would be "npc.ai[0]", which is quite hard to read.
        // This is all to just make beautiful, manageable, and clean code.
        public ref float AI_State => ref NPC.ai[0];
        public ref float AI_Timer => ref NPC.ai[1];
        public ref float AI_FlutterTime => ref NPC.ai[2];

        public override void SetStaticDefaults()
        {

            Main.npcFrameCount[Type] = 9;
           // NPCID.Sets.ExtraFramesCount[Type] = 9;
            //NPCID.Sets.DangerDetectRange[Type] = 700; // The amount of pixels away from the center of the npc that it tries to attack enemies.
            NPCID.Sets.AttackType[Type] = 90;
            NPCID.Sets.AttackTime[Type] = 60; // The amount of time it takes for the NPC's attack animation to be over once it starts.
            NPCID.Sets.AttackAverageChance[Type] = 0;
            NPCID.Sets.HatOffsetY[Type] = 4; // For when a party is active, the party hat spawns at a Y offset.

            // DisplayName.SetDefault("Flutter Slime"); // Automatic from localization files
            Main.npcFrameCount[NPC.type] = 9; // make sure to set this for your modnpcs.

            // Specify the debuffs it is immune to
            NPCID.Sets.DebuffImmunitySets.Add(Type, new NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[] {
                    BuffID.Poisoned // This NPC will be immune to the Poisoned debuff.
				}
            });
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
                    return "The Elder Plague Doctor";

                case 1:
                    return "Elder Plague Doctor";

                case 2:
                    return "The Elder Plague Doctor";

                case 3:
                    return "Lothar the Mastermind";

                case 4:
                    return "Elder Plague Doctor";

                default:
                    return "Elder Plague Doctor";

                    //default:
                    //     return "Lothar";
            }
        }




        



        public override void SetDefaults()
        {
            NPC.townNPC = true; // Sets NPC to be a Town NPC
            NPC.friendly = true; // NPC Will not attack player
            NPC.width = 36;
            NPC.height = 38;
            NPC.aiStyle = -1; //0
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 5;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
        }

        // Our AI here makes our NPC sit waiting for a player to enter range, jumps to attack, flutter mid-fall to stay afloat a little longer, then falls to the ground. Note that animation should happen in FindFrame
        public override void AI()
        {
            // The npc starts in the asleep state, waiting for a player to enter range
            switch (AI_State)
            {
                case (float)ActionState.Asleep:
             //       FallAsleep();
                    break;
                case (float)ActionState.Notice:
             //       Notice();
                    break;
                case (float)ActionState.Jump:
                    Jump();
                    break;
                case (float)ActionState.Hover:
                    Hover();
                    break;
                case (float)ActionState.Fall:


                    break;
            }
        }

        // Here in FindFrame, we want to set the animation frame our npc will use depending on what it is doing.
        // We set npc.frame.Y to x * frameHeight where x is the xth frame in our spritesheet, counting from 0. For convenience, we have defined a enum above.
        public override void FindFrame(int frameHeight)
        {
            // This makes the sprite flip horizontally in conjunction with the npc.direction.
            NPC.spriteDirection = NPC.direction;

            // For the most part, our animation matches up with our states.
            switch (AI_State)
            {
                case (float)ActionState.Asleep:
                    // npc.frame.Y is the goto way of changing animation frames. npc.frame starts from the top left corner in pixel coordinates, so keep that in mind.
                    // NPC.frame.Y = (int)Frame.Asleep * frameHeight;
                    NPC.frameCounter++;

                    AI_State = (float)ActionState.Hover;

                    break;
                case (float)ActionState.Notice:
                    // Going from Notice to Asleep makes our npc look like it's crouching to jump.
                    AI_State = (float)ActionState.Hover;

                    break;
                case (float)ActionState.Jump:
                    NPC.frame.Y = (int)Frame.Falling * frameHeight;
                    break;
                case (float)ActionState.Hover:
                    // Here we have 3 frames that we want to cycle through.
                    NPC.frameCounter++;

                    if (NPC.frameCounter < 100/2)
                    {
                        NPC.frame.Y = 1; //* frameHeight;
                    }
                    else if (NPC.frameCounter < 200/5)
                    {
                        NPC.frame.Y = 1 * frameHeight;
                    }
                    else if (NPC.frameCounter < 300/5)
                    {
                        NPC.frame.Y = 2 * frameHeight;
                    }
                    else if (NPC.frameCounter < 400/5)
                    {
                        NPC.frame.Y = 3 * frameHeight;
                    }
                    else if (NPC.frameCounter < 500/5)
                    {
                        NPC.frame.Y = 4 * frameHeight;
                    }
                    else if (NPC.frameCounter < 600/5)
                    {
                        NPC.frame.Y = 5 * frameHeight;
                    }
                    else if (NPC.frameCounter < 700/5)
                    {
                        NPC.frame.Y = 6 * frameHeight;
                    }
                    else if (NPC.frameCounter < 800/5)
                    {
                        NPC.frame.Y = 7 * frameHeight;
                    }
                    else if (NPC.frameCounter < 900/5)
                    {
                        NPC.frame.Y = 9 * frameHeight;
                    }
                    else if (NPC.frameCounter < 1000/5)
                    {
                        NPC.life -= 100;
                        if (Main.netMode == NetmodeID.MultiplayerClient)
                        {
                            // Because we want to spawn minions, and minions are NPCs, we have to do this on the server (or singleplayer, "!= NetmodeID.MultiplayerClient" covers both)
                            // This means we also have to sync it after we spawned and set up the minion
                            return;
                        }
                    }
                    else
                    {
                        NPC.frameCounter = 0;
                    }

                    break;
                case (float)ActionState.Fall:
                    NPC.frame.Y = (int)Frame.Falling * frameHeight;
                    break;
            }
        }

        // Here, because we use custom AI (aiStyle not set to a suitable vanilla value), we should manually decide when Flutter Slime can fall through platforms
        public override bool? CanFallThroughPlatforms()
        {
            if (AI_State == (float)ActionState.Fall && NPC.HasValidTarget && Main.player[NPC.target].Top.Y > NPC.Bottom.Y)
            {
                // If Flutter Slime is currently falling, we want it to keep falling through platforms as long as it's above the player
                return true;
            }

            return false;
            // You could also return null here to apply vanilla behavior (which is the same as false for custom AI)
        }

        

        //AI_State = (float)ActionState.Jump;

        private void Jump()
        {
            AI_Timer++;

            if (AI_Timer == 1)
            { 
                // after .66 seconds, we go to the hover state. //TODO, gravity?
                AI_State = (float)ActionState.Hover;
                AI_Timer = 0;
            }
        }

        private void Hover()
        {
            AI_Timer++;

            // Here we make a decision on how long this flutter will last. We check netmode != 1 to prevent Multiplayer Clients from running this code. (similarly, spawning projectiles should also be wrapped like this)
            // netMode == 0 is SP, netMode == 1 is MP Client, netMode == 2 is MP Server.
            // Typically in MP, Client and Server maintain the same state by running deterministic code individually. When we want to do something random, we must do that on the server and then inform MP Clients.
            if (AI_Timer == 1 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                // For reference: without proper syncing: https://gfycat.com/BackAnxiousFerret and with proper syncing: https://gfycat.com/TatteredKindlyDalmatian
                AI_FlutterTime = Main.rand.NextBool() ? 100 : 50;

                // Informing MP Clients is done automatically by syncing the npc.ai array over the network whenever npc.netUpdate is set.
                // Don't set netUpdate unless you do something non-deterministic ("random")
                NPC.netUpdate = true;
            }

            // Here we add a tiny bit of upward velocity to our npc.
         //   NPC.velocity += new Vector2(0, -.35f);

            // ... and some additional X velocity when traveling slow.
          //  if (Math.Abs(NPC.velocity.X) < 2)
          //  {
            //    NPC.velocity += new Vector2(NPC.direction * .05f, 0);
            //}

            // after fluttering for 100 ticks (1.66 seconds), our Flutter Slime is tired, so he decides to go into the Fall state.
            if (AI_Timer > AI_FlutterTime)
            {
               // AI_State = (float)ActionState.Fall;
               // AI_Timer = 0;
            }
        }
    }
}