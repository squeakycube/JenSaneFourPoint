using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace JenSaneFourPoint.Items
{
	public class PlagueBringer : ModItem
	{

        public int PotencyCost = 10;
       // public int PotencyCost = 5;
        public int PotencyChance = 100;

        public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("A potent plague weapon.");
		}

		public override void SetDefaults() 
		{
            Item.damage = 75;
            Item.DamageType = ModContent.GetInstance<PlagueDoctorDamageClass>();
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

    }
}