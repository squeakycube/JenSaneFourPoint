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
	public class PlaugeMask : ModItem
	{
			public override void SetStaticDefaults() {
            Tooltip.SetDefault("Boosts plauge damage by 25% and potency regeneration. Removes 30% damage from all non plauge attacks.");
        }

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Yellow;
			Item.defense = 10;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
            //return body.type == ModContent.ItemType<PlaugeRobes>();
            return body.type == ModContent.ItemType<PlaugePants>() && legs.type == ModContent.ItemType<PlaugeRobes>();
        }

        public override void UpdateEquip(Player player) {
            PlaugeReal p = player.GetModPlayer<PlaugeReal>();
            p.PlaugeSet1Equipped = true;

    //        if (p.MedBagEquipped = true)
    //        {
    //            if (Main.rand.Next(15) == 1)
     //           {
     //               p.Potency += 1;
    //            }
     //           player.GetDamage(ModContent.GetInstance<PlaugeDoctorDamageClass>()) += 0.45f;
     //           player.GetDamage(DamageClass.Generic) -= 0.3f;
     //
     //           player.setBonus += player.GetDamage(ModContent.GetInstance<PlaugeDoctorDamageClass>()) += 0.25f;
     //       }
		}

        //I need to change this to a VERY endgame craft
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