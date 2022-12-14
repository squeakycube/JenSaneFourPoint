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

namespace JenSaneFourPoint.Items.PR
{
	[AutoloadEquip(EquipType.Head)]
	public class PlagueMask : ModItem
	{
			public override void SetStaticDefaults() {
            Tooltip.SetDefault("Boosts plague damage by 25% and potency regeneration. Removes 30% damage from all non plague attacks.");
        }

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Yellow;
			Item.defense = 10;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ModContent.ItemType<PlaguePants>() && legs.type == ModContent.ItemType<PlagueRobes>();
        }

        public override void UpdateEquip(Player player) {
            PlagueReal p = player.GetModPlayer<PlagueReal>();
            p.PlagueSet1Equipped = true;
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "GlitchedFragment", 5);
            recipe.AddIngredient(ItemID.Silk, 150);
            recipe.AddIngredient(ItemID.SpookyHelmet, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}