using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using System;
using System.Collections.Generic;
using Terraria.GameInput;

namespace JenSaneFourPoint.Items
{
	public class PotencyCharm : ModItem
	{
		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 32;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 10);
			Item.rare = ItemRarityID.Purple;
		}

        public int RefKillCount;
        public override void SetStaticDefaults() {
			Tooltip.SetDefault("Greatly increases potency regeneration but removes 75% damage from all non plague doctor weapons and attacks.");
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            PlagueReal p = player.GetModPlayer<PlagueReal>();
            p.PlagueRegenItemEquipped = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SoulofMight, 30);
            recipe.AddIngredient(ItemID.SoulofSight, 30);
            recipe.AddIngredient(ItemID.SoulofFright, 30);
            recipe.AddIngredient(ItemID.HallowedBar, 60);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
