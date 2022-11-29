using Terraria;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Buffs
{
	public class Vampiric : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Vampiric");
			Description.SetDefault("Grants +6 defense, +5% damage, and increased life regeneration if it is currently night, and -2 defense and decreased movement speed if it is day.");
		}

		public override void Update(Player player, ref int buffIndex) {

if (!Main.dayTime) // If it's day the player gets negative effects.
			{
                player.statDefense += 6; // Grant a +4 defense boost to the player while the buff is active.
                player.GetDamage(DamageClass.Generic) += 0.05f; // Increase ALL player damage by 5%
                player.lifeRegen += 6;
            }

			else {

                player.statDefense -= 2;
                player.moveSpeed -= 0.1f;
            }
		}
	}
}
