using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Buffs
{
	public class CurseBringer : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Curse Bringer");
			Description.SetDefault(@"""Gives cursed flames to enemies you damage"""); //make this potion a rare retanizer drop
		}

		//public override void OnHitNPC() 
		public void OnHitNPC(Player player, NPC target, int buffIndex) //Example player may need to be changed to Player, or other way around
		{
			// Add the Onfire buff to the NPC for 1 second when the weapon hits an NPC
			// 60 frames = 1 second
            //Add /10 player damage to temp heal of max health. This also needs potion item
	//		target.AddBuff(BuffID.CursedInferno, 300);
   //         target.AddBuff(BuffID.Ichor, 300); //-WaterCandle effect for a buff, the ¨Midas¨ effect may also be a useful accessory.
		}
			}
		}