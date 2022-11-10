using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace JenSaneFourPoint.Items
{
	public class StardustTrident : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("MoltenTrident"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("It hurts to hold.");
		}

		public override void SetDefaults() 
		{
            Item.damage = 320;
           //Item.damage = 32;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Thrust;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shootSpeed = 139.5f;
			Item.value = Item.buyPrice(gold: 100);
			Item.mana = 6;

			//item.shoot = mod.ProjectileID.TridentBolt;
			Item.shoot = Mod.Find<ModProjectile>("NebulaTridentBolt").Type;
		}

		//public override void OnHitNPC() 
		public  void OnHitNPC(ExamplePlayer player, NPC target, int buffIndex)
		{
			// Add the Onfire buff to the NPC for 1 second when the weapon hits an NPC
			// 60 frames = 1 second
			target.AddBuff(BuffID.OnFire, 6000);
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.StarWrath, 1); //Nebula Fragment
            recipe.AddIngredient(Mod, "MoltenTrident", 1);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}