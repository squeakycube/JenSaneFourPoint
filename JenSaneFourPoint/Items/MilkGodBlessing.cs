using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace JenSaneFourPoint.Items
{
    public class MilkGodBlessing : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 30;
            Item.consumable = true;
            Item.rare = ItemRarityID.Red;
            Item.value = Item.buyPrice(gold: 5000);
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Grants an extra accessory slot forever.");
        }

        public override bool? UseItem(Player player)
        {
            ExamplePlayer p = player.GetModPlayer<ExamplePlayer>();
            p.ExtraPactSlot = true;

            return true;
        }
    }
}
