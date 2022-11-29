using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace JenSaneFourPoint.Items
{
	public class BloodEdge : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Bloodedge...");
		}

		public override void SetDefaults() 
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.value = Item.buyPrice(gold: 100);
		}

        public void OnHitNPC(Player player, NPC target, int buffIndex)
        {
            Item.damage += 1;
        }
	}
}