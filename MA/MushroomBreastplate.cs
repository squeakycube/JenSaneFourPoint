using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace JenSaneFourPoint.Items.MA
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Legs value here will result in TML expecting a X_Legs.png file to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Body)]
    public class MushroomBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A breastplate that boosts potency regeneration.");
        }

        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
            Item.rare = ItemRarityID.Green; // The rarity of the item
            Item.defense = 6; // The amount of defense the item will give when equipped
        }

        public override void UpdateEquip(Player player)
        {
            PlaugeReal p = player.GetModPlayer<PlaugeReal>();
            p.MushroomSet2Equipped = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GlowingMushroom, 50);
            recipe.AddIngredient(ItemID.Gel, 50);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
    }
}