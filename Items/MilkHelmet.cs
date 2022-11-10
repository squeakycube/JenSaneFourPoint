using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class MilkHelmet : ModItem
	{
			public override void SetStaticDefaults() {
            Tooltip.SetDefault("Boost minion damage by 60% but removes a minion and decreases other damage by 20%.");
        }

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Yellow;
			Item.defense = 7;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<MilkRobes>();
		}

		public override void UpdateArmorSet(Player player) {
            player.GetDamage(DamageClass.Magic) -= 0.2f;
            player.GetDamage(DamageClass.Ranged) -= 0.2f;
            player.GetDamage(DamageClass.Melee) -= 0.2f;


            player.setBonus += player.GetDamage(DamageClass.Summon) += 0.5f;
			player.GetDamage(DamageClass.Summon) += 0.6f; 
			player.maxMinions -= 1;
		}
        //I need to change this to a VERY endgame craft
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "GlitchedFragment", 5);
            recipe.AddIngredient(ItemID.Silk, 150);
            recipe.AddIngredient(ItemID.SpookyHelmet, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}