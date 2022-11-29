using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Buffs
{
	public class ManaRush : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Mana Rush");
			Description.SetDefault(@"""Increases max mana by 15%"""); //make this potion a rare retanizer drop
		} //            player.statLifeMax2 *= 2;

public override void Update(Player player, ref int buffIndex) {
            player.statManaMax2 += 10;
		}
			}
		}