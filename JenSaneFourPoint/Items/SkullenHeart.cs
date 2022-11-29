using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Items
{
	public class SkullenHeart : ModItem
	{
		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 32;
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
            p.CloakAccessoryEquipped = true;
        }


        

    }
}
