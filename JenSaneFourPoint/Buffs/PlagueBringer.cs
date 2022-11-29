using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Buffs
{
	public class PlagueBringer : ModBuff //or the horseman idk
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Plague Bringer");
			Description.SetDefault(@"""Inflicts enemies with disease and poison when they are hit.""");
		}

        // int lifeSteal = damage / 10;

        public void Update(Player player, ref int buffIndex)
        {
            //
            player.GetModPlayer<PlagueReal>().PlagueCause = true;
        }
    }
		}