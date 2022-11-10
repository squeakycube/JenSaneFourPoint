using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Items
{
	public class MilkSpoiledToAnUnholyDegree : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("HE WILL COME, BE NOT AFRAID");
		}

		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.buyPrice(gold: 10000);
		}

		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(Mod.Find<ModNPC>("Thomas Lord of Milk").Type);
		}

		public override Nullable<bool> UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
		{
			SoundEngine.PlaySound(SoundID.WormDig, player.position);
			if (Main.netMode != 1)
			{
				NPC.SpawnOnPlayer(player.whoAmI, Mod.Find<ModNPC>("Thomas").Type);
			}
			return true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			//recipe.AddIngredient(ItemID.TheMilkGodBlood, 10);
			recipe.AddIngredient(Mod, "TheMilkGodBlood");
           // recipe.AddIngredient(Mod, "TheMilkGodBlood"); //Hellstone Bar
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            //recipe.AddIngredient(ItemID.LuminiteBar, 5);
            recipe.AddTile(TileID.WorkBenches);
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
