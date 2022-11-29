using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace JenSaneFourPoint.Items
{
	public class VileOfToxin : ModItem
	{

        public int PotencyCost = 40;
       // public int PotencyCost = 5;
        public int PotencyChance = 100;

        public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("A potent plague weapon.");
		}

		public override void SetDefaults() 
		{
            Item.damage = 36;
            Item.DamageType = ModContent.GetInstance<PlagueDoctorDamageClass>();
            Item.width = 12;
			Item.height = 30;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shootSpeed = 9.5f;
			Item.value = Item.buyPrice(gold: 100);


        Item.shoot = Mod.Find<ModProjectile>("ThrowPot").Type; //Potency
        }


        public override bool CanUseItem(Player player)
        {
            PlagueReal modPlayer = player.GetModPlayer<PlagueReal>();

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
        }

    }
}