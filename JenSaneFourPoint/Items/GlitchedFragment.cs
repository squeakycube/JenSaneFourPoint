using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace JenSaneFourPoint.Items
{
	public class GlitchedFragment : ModItem
	{
		public override void SetStaticDefaults() 
		{
			//This will drop from glitch boss and will be an endgame crafting item
			Tooltip.SetDefault("It feels tingley.");
		}

		public override void SetDefaults() 
		{
			Item.DamageType = DamageClass.Ranged;
			Item.width = 20;
			Item.height = 20;
			Item.rare = 3;
			Item.UseSound = SoundID.Item1;
			Item.value = Item.buyPrice(silver: 10);
		}
	}
}