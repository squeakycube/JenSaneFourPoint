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
    [AutoloadEquip(EquipType.Legs)]
    public class MLPlaguePants : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Boosts plague damage by 75%, and potency regeneration.");
            DisplayName.SetDefault("Pantaloons Of Plague");
        }

        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
            Item.rare = ItemRarityID.Green; // The rarity of the item
            Item.defense = 20; // The amount of defense the item will give when equipped
        }

        public override void UpdateEquip(Player player)
        {
            PlagueReal p = player.GetModPlayer<PlagueReal>();
            p.MLPlagueSet3Equipped = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "GlitchedFragment", 1);
            recipe.AddIngredient(ItemID.LunarBar, 35);
            recipe.AddIngredient(Mod, "PlaguePants", 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}