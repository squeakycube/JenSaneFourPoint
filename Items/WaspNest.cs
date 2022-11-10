using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace JenSaneFourPoint.Items
{
	public class WaspNest : ModItem
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
			Tooltip.SetDefault("Increases health regeneration");
		}

        public void NPCKilled(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            // int buffID = BuffID.Regeneration; //This changes what buff you're applying to the player
            // int duration = 60; //How long the buff will last. Note that this value is in frames, so if you want the buff to last 1 second, put in 60 frames for the duration
            // player.AddBuff(buffID, duration);
            // player.GetDamage(DamageClass.Generic) *= 2f;
            RefKillCount += 1;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (Main.rand.Next(8) == 1)
            {
                PlaugeReal p = player.GetModPlayer<PlaugeReal>();
                p.Potency += 1;

            }
        }
    }
}
