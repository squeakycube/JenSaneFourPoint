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
	[AutoloadEquip(EquipType.Body)]
	internal class PlaugeRobes : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 14;
			Item.rare = ItemRarityID.Yellow;
			Item.vanity = true;
            Item.defense = 15;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Boosts plauge damage by 25% and potency regeneration.");
        }

        public override void SetMatch(bool male, ref int equipSlot, ref bool robes)
        {
            robes = true;
            // The equipSlot is added in ExampleMod.cs --> Load hook
            equipSlot = EquipLoader.GetEquipSlot(Mod, "PlaugeRobes_Legs", EquipType.Legs);
        }

        public void DrawHands(ref bool drawHands, ref bool drawArms)/* tModPorter Note: Removed. In SetStaticDefaults, use ArmorIDs.Body.Sets.HidesHands[Item.bodySlot] = false if you had drawHands set to true. If you had drawArms set to true, you don't need to do anything */ {
			drawHands = true;
		}

        public override void UpdateEquip(Player player)
        {
            PlaugeReal p = player.GetModPlayer<PlaugeReal>();
            p.PlaugeSet2Equipped = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "GlitchedFragment", 5);
            recipe.AddIngredient(ItemID.Silk, 250);
            recipe.AddIngredient(ItemID.SpookyBreastplate, 1);
            recipe.AddIngredient(ItemID.SpookyLeggings, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
