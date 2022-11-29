using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;
using JenSaneFourPoint.Items;

namespace JenSaneFourPoint.Items
{
	public class StoneOfTheDamned : ModItem
	{
		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 32;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 10);
			Item.rare = ItemRarityID.Orange;
            Item.healLife = 100;
        }

        int healingpotionItemIndex = Main.LocalPlayer.FindItem(ItemID.HealingPotion);

        public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases health regeneration");
		}

		public void UpdateAccessory(Player player, bool hideVisual, ref int healValue, bool quickHeal) {
            player.lifeRegenTime = 0;
            player.lifeRegen += 10;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BeetleHusk, 10);
            recipe.AddIngredient(ItemID.LifeFruit, 20);
            recipe.AddIngredient(ItemID.CharmofMyths, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
