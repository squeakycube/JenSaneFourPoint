using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using System;
using System.Collections.Generic;
using Terraria.GameInput;

namespace JenSaneFourPoint.Items
{
	public class FracturedHeartOfTheMoonLord : ModItem
	{
		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 32;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 10);
			Item.rare = ItemRarityID.Purple;
		}

        //public bool KillCount;

        public int RefKillCount;
        //public class GreenExclusiveAccessory : ExclusiveAccessory
        public override void SetStaticDefaults() {
			Tooltip.SetDefault("Greatly increases potency regernation using the life force stolen from the Moon Lord.");
		}
        //p.damageReduction = true;

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            PlaugeReal p = player.GetModPlayer<PlaugeReal>();
            p.PlaugeRegenMoonLordEquipped = true;
        }
    }
}
