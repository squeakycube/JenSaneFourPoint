using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace JenSaneFourPoint.Items
{
	public class ThowPotion : ModItem
	{

        public int PotencyCost = 150;
       // public int PotencyCost = 5;
        public int PotencyChance = 100;

        public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("MoltenTrident"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("It hurts to hold.");
		}

		public override void SetDefaults() 
		{
            //Item.damage = 320;
            Item.damage = 32;
            //Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.DamageType = ModContent.GetInstance<PlaugeDoctorDamageClass>();
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


        //item.shoot = mod.ProjectileID.TridentBolt;
        Item.shoot = Mod.Find<ModProjectile>("ThrowPot").Type; //Potency
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

    }
}