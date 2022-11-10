using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Items.HCA
{
	[AutoloadEquip(EquipType.Head)]
	public class HeartCrystalHelmet : ModItem
	{
			public override void SetStaticDefaults() {
			Tooltip.SetDefault("A helmet that boosts regeneration.");
		}

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.defense = 7;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<HeartCrystalBreastplate>() && legs.type == ModContent.ItemType<HeartCrystalLeggings>();
        }

        public override void UpdateEquip(Player player)
        {
            player.lifeRegenTime = 0;
            player.lifeRegen += 4;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Grants major regeneration";  // This is the setbonus tooltip
            player.lifeRegenTime = 0;
            player.lifeRegen += 8;
        }

        //I need to change this to a VERY endgame craft
        public override void AddRecipes() {
	Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LifeCrystal, 10);
            recipe.AddIngredient(ItemID.LifeFruit, 10);
            recipe.AddIngredient(ItemID.PhilosophersStone, 1);
            recipe.AddIngredient(ItemID.CharmofMyths, 1);
            recipe.AddIngredient(ItemID.ChlorophyteHelmet, 1);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}