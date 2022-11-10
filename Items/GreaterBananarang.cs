using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace JenSaneFourPoint.Items
{
	public class GreaterBananarang : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("MoltenTrident"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("A great bannana weapon once wielded by Nor Mal the Monke Slayer.");
		}

		public override void SetDefaults() 
		{
			Item.damage = 66;
			//item.melee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 6;
			Item.useAnimation = 6;
			Item.useStyle = ItemUseStyleID.Thrust;
			Item.knockBack = 8;
			Item.value = 10000;
			Item.rare = 3;
            Item.maxStack = 10;
            Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shootSpeed = 18.5f;
			Item.value = Item.buyPrice(gold: 100);
			//item.mana = 12;

			//item.shoot = mod.ProjectileID.TridentBolt;
			Item.shoot = Mod.Find<ModProjectile>("BanGreat").Type;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ChlorophyteOre, 15);
			recipe.AddIngredient(ItemID.Bananarang, 30);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}