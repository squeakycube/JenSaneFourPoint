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

namespace JenSaneFourPoint.Items.PRML
{
	[AutoloadEquip(EquipType.Head)]
	public class MLPlagueMask : ModItem
	{
			public override void SetStaticDefaults() {
            Tooltip.SetDefault("Boosts plague damage by 75%, and potency regeneration. Removes 30% damage from all non plague attacks.");
            DisplayName.SetDefault("Mask Of Disease");
        }

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Yellow;
			Item.defense = 20;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ModContent.ItemType<MLPlaguePants>() && legs.type == ModContent.ItemType<MLPlagueRobes>();
        }

        public override void UpdateEquip(Player player) {
            PlagueReal p = player.GetModPlayer<PlagueReal>();
            p.MLPlagueSet1Equipped = true;
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "GlitchedFragment", 1);
            recipe.AddIngredient(ItemID.LunarBar, 30);
            recipe.AddIngredient(Mod, "PlagueMask", 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}