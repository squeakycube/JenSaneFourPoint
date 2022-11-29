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
    public class TownGuard : ModNPC
    {
        public override string Texture => "JenSaneFourPoint/NPCs/TownGuard";
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 26; // The amount of frames the NPC has

            NPCID.Sets.ExtraFramesCount[Type] = 0; // Generally for Town NPCs, but this is how the NPC does extra things such as sitting in a chair and talking to other NPCs.
            NPCID.Sets.AttackFrameCount[Type] = 4;
            NPCID.Sets.DangerDetectRange[Type] = 9700; // The amount of pixels away from the center of the npc that it tries to attack enemies.
            NPCID.Sets.AttackType[Type] = 0;
            NPCID.Sets.AttackTime[Type] = 30; // The amount of time it takes for the NPC's attack animation to be over once it starts.
            NPCID.Sets.AttackAverageChance[Type] = 9;
            NPCID.Sets.HatOffsetY[Type] = 4; // For when a party is active, the party hat spawns at a Y offset.

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f,
                Direction = 1
            };
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true; // Sets NPC to be a Town NPC
            NPC.friendly = true; // NPC Will not attack player
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 45;
            NPC.defense = 30;
            NPC.lifeMax = 850;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            TownNPCStayingHomeless = true;

            AnimationType = NPCID.Guide;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
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

                    if (NPC.downedMechBossAny)
                {
                        return true;
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
                    return "Guard";

                case 1:
                    return "Guard";

                case 2:
                    return "Guard";

                case 3:
                    return "Guard";

                case 4:
                    return "Guard";

                default:
                    return "Guard";
            }
        }




        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();

                       // These are things that the NPC has a chance of telling you when you talk to it.
            chat.Add("I got hit on the head while fighting a demon eye and now I cant stop dancing!");
            chat.Add("I will guard this town with my life.");
            chat.Add("I couldnt save my old town so I moved here in my loss.");
            chat.Add("I used to be an adventurer like you untill I took an arrow to the knee.", 0.7);
            chat.Add("I don't feel so good...*vomits*", 0.5);
            return chat;
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 40;
            knockback = 6f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 0;
            randExtraCooldown = 0;
        }

        // todo: implement
        public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
            projType = ProjectileID.WoodenArrowFriendly;
            attackDelay = 1;
         }

        public override void AI()
        {
            NPC.homeless = true; // Make sure it stays homeless
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }
    }
}