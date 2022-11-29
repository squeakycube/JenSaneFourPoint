using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Buffs
{
	public class PotencyRegeneration : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Potency Regeneration");
			Description.SetDefault(@"""Increases potency regeneration"""); //make this potion a rare retanizer drop
		} //            player.statLifeMax2 *= 2;


        public override void Update(Player player, ref int buffIndex)
        {
            PlagueReal p = player.GetModPlayer<PlagueReal>();
            p.PlagueRegenPotion = true;
        }
    }
		}