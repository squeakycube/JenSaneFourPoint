using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace JenSaneFourPoint.Items
{
	public class PlaugeBringer : ModItem
	{

        public int PotencyCost = 12;
       // public int PotencyCost = 5;
        public int PotencyChance = 100;

        public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("MoltenTrident"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("A potent plauge weapon.");
		}

		public override void SetDefaults() 
		{
            Item.damage = 24;
            Item.DamageType = ModContent.GetInstance<PlaugeDoctorDamageClass>();
            Item.width = 60;
            Item.height = 32;
            Item.useTime = 2;
            Item.useAnimation = 2;
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.knockBack = 3;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = 3;
            Item.UseSound = SoundID.Item12;
            Item.autoReuse = true;
            Item.shoot = Mod.Find<ModProjectile>("CosmicRay").Type; //Potency
            Item.shootSpeed = 6f;
        }


        public override bool CanUseItem(Player player)
        {
            PlaugeReal modPlayer = player.GetModPlayer<PlaugeReal>();

            if (modPlayer.Potency < this.PotencyCost)
            {
                return false;
            }
            else
            {
                modPlayer.RemovePotency(this.PotencyChance, this.PotencyCost);
            }
            return base.CanUseItem(player);
        }

public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HealingPotion, 39);
            recipe.AddIngredient(ItemID.Bottle, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            // recipe.AddRecipe(); //Ankh Shield Destroyer Emblem
        }

    }
}