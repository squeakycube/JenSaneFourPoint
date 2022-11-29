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
	[AutoloadEquip(EquipType.Body)]
	internal class MLPlagueRobes : ModItem
	{
		public override void SetDefaults() {
            //DisplayName.SetDefault("Garment of Disease");
            Item.width = 18;
			Item.height = 14;
			Item.rare = ItemRarityID.Yellow;
			Item.vanity = true;
            Item.defense = 20;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Boosts plague damage by 75%, and potency regeneration.");
            DisplayName.SetDefault("Garment Of Disease");
        }

        public override void SetMatch(bool male, ref int equipSlot, ref bool robes)
        {
            robes = true;
            // The equipSlot is added in ExampleMod.cs --> Load hook
            equipSlot = EquipLoader.GetEquipSlot(Mod, "PlagueRobes_Legs", EquipType.Legs);
        }

        public void DrawHands(ref bool drawHands, ref bool drawArms)/* tModPorter Note: Removed. In SetStaticDefaults, use ArmorIDs.Body.Sets.HidesHands[Item.bodySlot] = false if you had drawHands set to true. If you had drawArms set to true, you don't need to do anything */ {
			drawHands = true;
		}

        public override void UpdateEquip(Player player)
        {
            PlagueReal p = player.GetModPlayer<PlagueReal>();
            p.MLPlagueSet2Equipped = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "GlitchedFragment", 1);
            recipe.AddIngredient(ItemID.LunarBar, 45);
            recipe.AddIngredient(Mod, "PlagueRobes", 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
