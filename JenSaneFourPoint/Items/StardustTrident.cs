using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace JenSaneFourPoint.Items
{
	public class StardustTrident : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("It hurts to hold.");
		}

		public override void SetDefaults() 
		{
            Item.damage = 320;
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

			Item.shoot = Mod.Find<ModProjectile>("NebulaTridentBolt").Type;
		}

		public  void OnHitNPC(Player player, NPC target, int buffIndex)
		{
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