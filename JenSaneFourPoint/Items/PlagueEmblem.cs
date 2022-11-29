using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace JenSaneFourPoint.Items
{
    public class PlagueEmblem : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 26;
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 10);
            Item.rare = ItemRarityID.Blue;
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases plague damage by 15%");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
            {
            player.GetDamage(ModContent.GetInstance<PlagueDoctorDamageClass>()) += 0.15f; //            Item.DamageType = ModContent.GetInstance<Chemical>();
        }
    }
}
