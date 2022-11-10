using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace JenSaneFourPoint
{
    public class ExamplePlayer : ModPlayer
    {
        public bool examplePet;
        public bool exampleLightPet;

        public bool tmmcPet;

        public bool damageReduction;
        public bool CloakAccessoryEquipped;
        public bool LifeStealOn;

        public static int KillCount { get; set; } = 0;
        public int RefKillCount;

        //public int MinionFruits;

        public override void ResetEffects()
        {
            damageReduction = false;
        }

            public bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref string deathText)
        {
            if (this.damageReduction && damage > 350)
                if (Main.rand.Next(8) == 1)
                    damage = 350;
            Player.NinjaDodge();
            damage = 0;

            return true;
        }

        public void OnHitNPC(Player target, int damage, float knockback, bool crit)
        {
                           int lifeSteal = damage / 3;
                        //   player.statLife += 100;
                        //   player.HealEffect(100, true);
        }

    }
}