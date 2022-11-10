using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Items
{
	public class PlaugeAbsorb : ModItem
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
			Tooltip.SetDefault("Increases health regeneration for teammates if the down key is pressed but it renders you immobile.");
		}
        //p.damageReduction = true;

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<PlaugeReal>().TeamHealAccessoryEquipped = true;
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
