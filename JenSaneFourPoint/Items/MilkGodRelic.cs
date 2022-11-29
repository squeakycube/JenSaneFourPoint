using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Items
{
    public class MilkGodRelic : ModItem //expert mode item
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 10);
            Item.rare = ItemRarityID.Red;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Reduces damage taken by 30%");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance = 1f - (0.7f * (1f - player.endurance));
        }
    }
}
