using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace JenSaneFourPoint.Items
{
    public class DeathToken : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 10);
            Item.rare = ItemRarityID.Blue;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Use all 1000 potency to heal your team for full health but leaving you unable to use potency for a short amount of time.");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
            {
            player.GetModPlayer<PlagueReal>().MassMaxHealAccessoryEquipped = true;
        }
    }
}
