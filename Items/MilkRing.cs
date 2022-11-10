using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Items
{
	public class MilkRing : ModItem
	{
		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 32;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 10);
			Item.rare = ItemRarityID.Green;
		}

	//public class GreenExclusiveAccessory : ExclusiveAccessory
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Gives 3 minion summons but decreases summon damage by 10% and removes 60% max health.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
            // 50% melee and ranged damage increase
            player.GetDamage(DamageClass.Summon) -= 0.1f;
            player.maxMinions += 3;
            player.statLifeMax2 /= 3;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "TheMilkGodBlood", 30);
            recipe.AddIngredient(Mod, "MilkEmblem", 1);
            recipe.AddIngredient(Mod, "TheMilkGodBlood", 30);
            //recipe.AddIngredient(Mod, "SoulofBlight", 15); //Super Healing Potion
            recipe.AddIngredient(Mod, "SoulOfBlight", 15); //TheMilkGodBlood
            recipe.AddIngredient(ItemID.SuperHealingPotion, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
	}
}
