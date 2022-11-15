using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Items.MA
{
	[AutoloadEquip(EquipType.Head)]
	public class MushroomHelmet : ModItem
	{
			public override void SetStaticDefaults() {
			Tooltip.SetDefault("A helmet that boosts potency regeneration.");
		}

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.defense = 5;
		}

	//	public override bool IsArmorSet(Item head, Item body, Item legs) {
	//		return body.type == ModContent.ItemType<HeartCrystalBreastplate>() && legs.type == ModContent.ItemType<HeartCrystalLeggings>();
      //  }

        public override void UpdateEquip(Player player)
        {
            PlaugeReal p = player.GetModPlayer<PlaugeReal>();
            p.MushroomSet1Equipped = true;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Grants major regeneration";  // This is the setbonus tooltip
            player.GetDamage(ModContent.GetInstance<PlaugeDoctorDamageClass>()) += 0.1f;
        }

        //I need to change this to a VERY endgame craft
        public override void AddRecipes() {
	Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.GlowingMushroom, 50);
            recipe.AddIngredient(ItemID.Gel, 50);
            recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}