using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Items
{
	public class PlaugeRegen : ModItem
	{
		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 32;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 10);
			Item.rare = ItemRarityID.Blue;
		}

        //public bool KillCount;

        public int RefKillCount;
        //public class GreenExclusiveAccessory : ExclusiveAccessory
        public override void SetStaticDefaults() {
			Tooltip.SetDefault("Greatly increases potency regernation but removes 75% damage from all non plauge doctor weapons and attacks.");
		}
        //p.damageReduction = true;

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) -= 0.75f;
            player.GetDamage(ModContent.GetInstance<PlaugeDoctorDamageClass>()) += 0.75f;

            if (player.GetModPlayer<PlaugeReal>().Potency < player.GetModPlayer<PlaugeReal>().PotencyMax)
                if (Main.rand.Next(2) == 1)
                    player.GetModPlayer<PlaugeReal>().Potency += 1;
            {
         //       if (PlaugeReal.Potency >= 100)
         //   {
            //        PlaugeReal.Potency -= 5;
             //   player.lifeRegen += 50;
             //       Main.NewText("Down");
                    //player.noKnockback = true;
                    //player.hasPaladinShield = true;

           //     }
            }
        }

    }
}
