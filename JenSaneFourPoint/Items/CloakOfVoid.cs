using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace JenSaneFourPoint.Items
{
    public class CloakOfVoid : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 10);
            Item.rare = ItemRarityID.Blue;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Not finished, needs 1.4.4");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
            {
            player.GetModPlayer<DashPlayer>().CloakAccessoryEquipped = true;
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
