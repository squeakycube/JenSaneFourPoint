using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Buffs
{
	public class CritHit : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("CritHit");
			Description.SetDefault(@"""Gives health back if damage is delt to enemies""");
		}

        //public override void OnHitNPC() 
        public void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) //Example player may need to be changed to Player, or other way around
        {
            if (crit)
            {
                // Add the Onfire buff to the NPC for 1 second when the weapon hits an NPC
                // 60 frames = 1 second
                //Add /10 player damage to temp heal of max health. This also needs potion item
                //target.AddBuff(BuffID.OnFire, 6000);
                int newLife = Main.rand.Next(40, 80);
                player.statLife += newLife;
                player.HealEffect(newLife);
            }
		}
			}
		}