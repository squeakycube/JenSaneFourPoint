using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System;
using JenSaneFourPoint.Buffs;

namespace JenSaneFourPoint.Items
{
	public class PlagueDoctorMedicalSupplies : ModItem
	{
		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 32;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 10);
			Item.rare = ItemRarityID.Blue;
		}

        public int RefKillCount;
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("Allows the use and regeneration of potency. Increases life regeneration for teammates who are nearby.");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            PlagueReal p = player.GetModPlayer<PlagueReal>();
            p.MedBagEquipped = true;


        }

                    public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ManaCrystal, 1);
            recipe.AddIngredient(ItemID.ManaFlower, 1);
            recipe.AddIngredient(ItemID.Ruby, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
            }
        }

    }