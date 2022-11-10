using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace JenSaneFourPoint.Items
{
    public class eee : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 10);
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
        }

        //public class GreenExclusiveAccessory : ExclusiveAccessory
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Not finished");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(ModContent.GetInstance<PlaugeDoctorDamageClass>()) += 20.75f; //            Item.DamageType = ModContent.GetInstance<Chemical>();

            ExamplePlayer p = player.GetModPlayer<ExamplePlayer>();
            p.LifeStealOn = true;
        }
    }
}
