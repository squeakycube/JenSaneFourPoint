using JenSaneFourPoint.NPCs;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Items
{
	public class BossSummon : ModItem
	{
			public override void SetStaticDefaults() {
			Tooltip.SetDefault("The underworld would like this.");
            DisplayName.SetDefault("Unholy Tome");
            ItemID.Sets.SortingPriorityBossSpawns[Item.type] = 13; // This helps sort inventory know this is a boss summoning item.
		}

		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 20;
			Item.rare = ItemRarityID.Cyan;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.UseSound = SoundID.Item44;
			Item.consumable = true;
		}

		// We use the CanUseItem hook to prevent a player from using this item while the boss is present in the world.
		public override bool CanUseItem(Player player) {
			// "player.ZoneUnderworldHeight" could also be written as "player.position.Y / 16f > Main.maxTilesY - 200"
			return player.ZoneUnderworldHeight;
			//return player.ZoneUnderworldHeight && !NPC.AnyNPCs(ModContent.NPCType<NPCs.GreaterDemon>()) && !NPC.AnyNPCs(ModContent.NPCType<GreaterDemon>()) && !NPC.AnyNPCs(ModContent.NPCType<GreaterDemon>());
		}

		public override Nullable<bool> UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */ {
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.GreaterDemon>());
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.GreaterDemon>());
			return true;
		}

		public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ObsidianBrick, 50);
			recipe.AddIngredient(ItemID.GuideVoodooDoll, 1);
			recipe.AddTile(TileID.WorkBenches);
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}