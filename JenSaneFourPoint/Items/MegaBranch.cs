using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace JenSaneFourPoint.Items
{
	public class MegaBranch : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("MoltenTrident"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Tree go brrr.");
		}

		public override void SetDefaults() 
		{
			Item.damage = 5;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 52;
			Item.height = 50;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 5;
			Item.rare = 2;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shootSpeed = 139.5f;
			Item.value = Item.buyPrice(gold: 50);
            Item.scale = 3f;
        }

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 150);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}