using JenSaneFourPoint.Items;
using JenSaneFourPoint.Projectiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;

namespace JenSaneFourPoint.Items
{
	public class InsanityMode : ModItem
	{
		public override void SetDefaults() {
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 1;
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.buyPrice(gold: 1);
           // Item.buffType = ModContent.BuffType<Buffs.Vampiric>(); // Specify an existing buff to be applied when used.
           // Item.buffTime = 5400; // The amount of time the buff declared in Item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }

        public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases game difficult. WARNING: This will last forever.");
		}

        public override bool? UseItem(Player player)
        {
            if (Main.expertMode)
            {
                ExamplePlayer p = player.GetModPlayer<ExamplePlayer>();
                p.InsaneMode = true;
                Main.NewText("Insanity Mode Activated", new Color(255, 50, 50));
                // Main.NewText("Insanity Mode Activated");
                if (Main.netMode == NetmodeID.Server)
                    NetMessage.SendData(MessageID.WorldData);
                if (!Main.dedServ)
                    SoundEngine.PlaySound(SoundID.Roar, Main.LocalPlayer.Center);
                return true;
            }
            else
            {
                Main.NewText("Sorry, Insanity Mode Can Only Be Activated In Expert/Master Mode Worlds");
                return false;
            }
        }


    }
}
