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
    [AutoloadEquip(EquipType.Legs)]
    public class PlaguePants : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Boosts plague damage by 25% and potency regeneration.");
        }

        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
            Item.rare = ItemRarityID.Green; // The rarity of the item
            Item.defense = 7; // The amount of defense the item will give when equipped
        }

        public override void UpdateEquip(Player player)
        {
            PlagueReal p = player.GetModPlayer<PlagueReal>();
            p.PlagueSet3Equipped = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "GlitchedFragment", 5);
            recipe.AddIngredient(ItemID.Silk, 250);
            //recipe.AddIngredient(ItemID.SpookyBreastplate, 1);
            recipe.AddIngredient(ItemID.SpookyLeggings, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }

    }
}