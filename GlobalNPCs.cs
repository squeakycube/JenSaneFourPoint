using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using JenSaneFourPoint.Items;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ExampleMod.GlobalNPCs
{
    // This file shows numerous examples of what you can do with the extensive NPC Loot lootable system.
    // Despite this file being GlobalNPC, everything here can be used with a ModNPC as well! See examples of this in the Content/NPCs folder.
    public class ExampleNPCLoot : GlobalNPC
    {
        // ModifyNPCLoot uses a unique system called the ItemDropDatabase, which has many different rules for many different drop use cases.
        // Here we go through all of them, and how they can be used.
        // There are tons of other examples in vanilla! In a decompiled vanilla build, GameContent/ItemDropRules/ItemDropDatabase adds item drops to every single vanilla NPC, which can be a good resource.

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            
            // We will now use the Guide to explain many of the other types of drop rules.

            // Editing an existing drop rule
            if (npc.type == NPCID.Plantera)
            {
                // Dreadnautilus, known as BloodNautilus in the code, drops SanguineStaff. The drop rate is 100% in Expert mode and 50% in Normal mode. This example will change that rate.
                // The vanilla code responsible for this drop is: ItemDropRule.NormalvsExpert(4269, 2, 1)
                // The NormalvsExpert method creates a DropBasedOnExpertMode rule, and that rule is made up of 2 CommonDrop rules. We'll need to use this information in our casting to properly identify the recipe to edit.

                // There are 2 options. One option is remove the original rule and then add back a similar rule. The other option is to modify the existing rule.
                // It is preferred to modify the existing rule to preserve compatibility with other mods.

                // Adjust the existing rule: Change the Normal mode drop rate from 50% to 33.3%
                foreach (var rule in npcLoot.Get())
                {
                    // You must study the vanilla code to know what to objects to cast to.
                    npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("SoulOfBlight").Type, 12)); // 1% chance to drop Confetti
                }

                // Remove the rule, then add another rule: Change the Normal mode drop rate from 50% to 16.6%
                /*
				npcLoot.RemoveWhere(
					rule => rule is DropBasedOnExpertMode drop && drop.ruleForNormalMode is CommonDrop normalDropRule && normalDropRule.itemId == ItemID.SanguineStaff
				);
				npcLoot.Add(ItemDropRule.NormalvsExpert(4269, 6, 1));
				*/
            }
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            // This example does not use the AppliesToEntity hook, as such, we can handle multiple npcs here by using if statements.
            if (type == NPCID.Dryad)
            {
                // Adding an item to a vanilla NPC is easy:
                // This item sells for the normal price.
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<DryadLeaf>());
                nextSlot++; // Don't forget this line, it is essential.
            }
        }
                //    public void ModifyGlobalLoot(Player player)
                //    {
                //        // player.KillCount++;
                //        ExamplePlayer p = player.GetModPlayer<ExamplePlayer>();
                //         p.KillCount++;
                //      }

                // ModifyGlobalLoot allows you to modify loot that every NPC should be able to drop, preferably with a condition.
                // Vanilla uses this for the biome keys, souls of night/light, as well as the holiday drops.
                // Any drop rules in ModifyGlobalLoot should only run once. Everything else should go in ModifyNPCLoot.
            }
}