using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Buffs
{
    public class Plague : ModBuff
    {



        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plague");
            Description.SetDefault(@"""Damages you over time""");
            Main.debuff[Type] = true;  // Is it a debuff?
            Main.buffNoSave[Type] = true; // Causes this buff not to persist when exiting and rejoining the world
            BuffID.Sets.LongerExpertDebuff[Type] = true; // If this buff is a debuff, setting this to true will make this buff last twice as long on players in expert mode

        }

        // int lifeSteal = damage / 10;



        public override void Update(Player player, ref int buffIndex)
        {
                player.GetModPlayer<ExamplePlayer>().lifeRegenDebuff = true;

        }
    }
}