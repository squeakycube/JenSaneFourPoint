using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Items
{
    public class BootsOfSilver : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Boots of Silver");
            Tooltip.SetDefault("Sweet Dreams");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 24;
            Item.accessory = true; // Makes this item an accessory.
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(gold: 1000); // Sets the item sell price to one gold coin.
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.accRunSpeed = 23f; // The player's maximum run speed with accessories
            player.moveSpeed += 0.07f; // The acceleration multiplier of the player's movement speed
        }
    }
}
