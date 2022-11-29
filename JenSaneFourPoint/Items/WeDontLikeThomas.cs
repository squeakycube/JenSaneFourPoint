using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Items
{
	public class WeDontLikeThomas : ModItem
	{
		public override void SetDefaults() {
			Item.width = 77;
			Item.height = 103;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 10);
			Item.rare = ItemRarityID.Green;
		}

        public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases health regeneration for teammates if N key is pressed and held, but it renders you immobile.");
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            PlagueReal p = player.GetModPlayer<PlagueReal>();
            p.WeDontLikeThomas = true;
        }

                    public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
        

    }
}
