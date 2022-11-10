using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace JenSaneFourPoint.Items
{
	public class SatanistBook : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("Wiresword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("A book forgot to time, does one dare to cast its spells?");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults() 
		{
			//item.damage = 70;
			//item.melee = true;
			//item.width = 40;
			//item.height = 40;
			//item.useTime = 20;
			//item.useAnimation = 20;
			//item.useStyle = 1;
			//item.knockBack = 6;
			//item.value = 10000;
			//item.rare = 2;
			//item.UseSound = SoundID.Item1;
			//item.autoReuse = true;
			Item.width = 40;
			Item.height = 40;

			Item.DamageType = DamageClass.Magic;
			Item.mana = 100;
			Item.damage = 835;
			Item.knockBack = 13.55f;
			Item.crit = 30;
			Item.noMelee = true;

			Item.useTime = 440;
			Item.useAnimation = 440;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.UseSound = SoundID.Item43;
			
			Item.shoot = ProjectileID.DD2ExplosiveTrapT3Explosion;
			Item.shootSpeed = 9.25f;

			Item.value = Item.buyPrice(gold: 100);
			Item.rare = ItemRarityID.Blue;
		}
	}
}