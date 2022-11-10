using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace JenSaneFourPoint.Items
{
    public class PlaugeEmblem : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 10);
            Item.rare = ItemRarityID.Blue;
        }

        //public class GreenExclusiveAccessory : ExclusiveAccessory
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases chemical damage by 15%");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
            {
            player.GetDamage(ModContent.GetInstance<PlaugeDoctorDamageClass>()) += 0.15f; //            Item.DamageType = ModContent.GetInstance<Chemical>();
        }
    }
}
