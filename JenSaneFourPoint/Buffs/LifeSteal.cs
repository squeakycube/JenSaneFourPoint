using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Buffs
{
	public class LifeSteal : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Life Steal");
			Description.SetDefault(@"""Gives health back if damage is delt to enemies""");
		}

        // int lifeSteal = damage / 10;

        public void Update(Player player, ref int buffIndex)
        {
            //
            player.GetModPlayer<ExamplePlayer>().LifeStealOn = true;
        }

        //public override void OnHitNPC() 
        //public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
//        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
//        {
            // Inflict the OnFire debuff for 1 second onto any NPC/Monster that this hits.
            // 60 frames = 1 second
//            int lifeSteal = damage / 3;
//            player.statLife += 100;
//            player.HealEffect(100, true);
//        }
    }
		}