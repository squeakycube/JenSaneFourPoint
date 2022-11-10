using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Items
{
	[AutoloadEquip(EquipType.Body)]
	internal class MilkRobes : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 14;
			Item.rare = ItemRarityID.Yellow;
			Item.vanity = true;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Boost minion damage by 60% but removes a minion and decreases other damage by 20%.");
        }

        public override void SetMatch(bool male, ref int equipSlot, ref bool robes) {
			robes = true;
			// The equipSlot is added in ExampleMod.cs --> Load hook
			equipSlot = EquipLoader.GetEquipSlot(Mod, "MilkRobes_Legs", EquipType.Legs);
		}

		public void DrawHands(ref bool drawHands, ref bool drawArms)/* tModPorter Note: Removed. In SetStaticDefaults, use ArmorIDs.Body.Sets.HidesHands[Item.bodySlot] = false if you had drawHands set to true. If you had drawArms set to true, you don't need to do anything */ {
			drawHands = true;
		}

        public override void UpdateArmorSet(Player player)
        {
            player.GetDamage(DamageClass.Magic) -= 0.2f;
            player.GetDamage(DamageClass.Ranged) -= 0.2f;
            player.GetDamage(DamageClass.Melee) -= 0.2f;

            player.setBonus += player.GetDamage(DamageClass.Summon) += 0.5f;
            player.GetDamage(DamageClass.Summon) += 0.6f;
            player.maxMinions -= 1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "GlitchedFragment", 5);
            recipe.AddIngredient(ItemID.Silk, 250);
            recipe.AddIngredient(ItemID.SpookyBreastplate, 1);
            recipe.AddIngredient(ItemID.SpookyLeggings, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
