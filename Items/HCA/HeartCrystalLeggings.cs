using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace JenSaneFourPoint.Items.HCA
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Legs value here will result in TML expecting a X_Legs.png file to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Legs)]
    public class HeartCrystalLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Leggings that boosts regeneration.");
        }

        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
            Item.rare = ItemRarityID.Green; // The rarity of the item
            Item.defense = 5; // The amount of defense the item will give when equipped
        }

        public override void UpdateEquip(Player player)
        {
            player.lifeRegenTime = 0;
            player.lifeRegen += 3;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LifeCrystal, 5);
            recipe.AddIngredient(ItemID.LifeFruit, 5);
            recipe.AddIngredient(ItemID.ChlorophyteGreaves, 1);
            recipe.AddIngredient(ItemID.PhilosophersStone, 1);
            recipe.AddIngredient(ItemID.CharmofMyths, 1);
            recipe.AddIngredient(ItemID.ChlorophyteGreaves, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
    }
}