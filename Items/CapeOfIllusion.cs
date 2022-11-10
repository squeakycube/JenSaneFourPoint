using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Items
{
    public class CapeOfIllusion : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 10);
            Item.rare = ItemRarityID.Blue;
        }

        //public class GreenExclusiveAccessory : ExclusiveAccessory
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("1/8 Chance to dodge an attack");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //ExamplePlayer p = player.GetModPlayer<ExamplePlayer>();
            //p.damageReduction = true;
            player.GetModPlayer<ExamplePlayer>().damageReduction = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BeetleHusk, 10);
            recipe.AddIngredient(ItemID.LifeFruit, 20);
            recipe.AddIngredient(ItemID.BlackBelt, 1);
            recipe.AddIngredient(Mod, "SoulOfBlight", 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
