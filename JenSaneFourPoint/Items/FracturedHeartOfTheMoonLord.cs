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

        public override void SetStaticDefaults() {
			Tooltip.SetDefault("Greatly increases potency regernation using the life force stolen from the Moon Lord. 350% plague damage boost.");
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            PlagueReal p = player.GetModPlayer<PlagueReal>();
            p.PlagueRegenMoonLordEquipped = true;
            player.GetDamage(ModContent.GetInstance<PlagueDoctorDamageClass>()) += 3.5f; //            Item.DamageType = ModContent.GetInstance<Chemical>();

        }
    }
}
