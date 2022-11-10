using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using System;
using System.Collections.Generic;
using Terraria.GameInput;

namespace JenSaneFourPoint
{
    public class PlaugeReal : ModPlayer {
        // These indicate what direction is what in the timer arrays used

        public int Potency = 0;
        public int PotencyConsume = 0;
        public int PotencyMax = 1000;
        public int PotencySickness = 3000;
        public int PotencyRegen = 1;
        public int dancerWeaponDamage = 0;
        public float dancerWeaponKnockback = 0f;
        public int PotencyDivide = 0;
        public bool InHealDistance;

        public bool TeamHealAccessoryEquipped;//            TeamHealAccessoryEquipped = false;
        public bool MassMaxHealAccessoryEquipped;

        public bool healingPrefix;

        public bool TeamHeal;

        public void RemovePotency(int chance, int number)
        {
            for (int i = 0; i < number; i++)
            {
                if (Main.rand.Next(100) < (chance - PotencyConsume))
                {
                    Potency--;
                }
            }
        }


        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            //if (JenSaneFourPoint.FreezeKey.JustPressed)
                if (JenSaneFourPoint.MegaMassHealKey.JustPressed)
                {
                if (TeamHealAccessoryEquipped = true)
                {
                    if (Potency >= 999)
                    {
                        Potency -= 8000;
                        Player.statLife += 700;
                        var Player2 = Main.player[Main.myPlayer];
                        if (Player != Player2 && Player.miscCounter % 10 == 0)
                        {
                            if (Player2.team == Player.team && Player.team != 0)
                            {
                                Player2.statLife += 800;
                            }
                        }
                    }
                }
           }
        }


        public override void ResetEffects()
        {
            TeamHealAccessoryEquipped = false;
            InHealDistance = false;
            MassMaxHealAccessoryEquipped = false;

            if (Potency >= 100)
            {
                if (Potency < PotencyMax)
                {
                    if (Main.rand.Next(2) == 1)
                        Potency += PotencyRegen;
                }
            }
            else
            {
                Player.moveSpeed -= 0.5f;
                if (Main.rand.Next(5) == 1)
                {
                    Potency += PotencyRegen;
                }
                //    }
            }


            // PotencyDivide = Potency /= 4;

            // if (!Player.controlDown)
            //   {
            //       PotencyAbsorbDown = true;
            //  }
            //if (Player.controlDown && PotencyAbsorbDown = true && Potency > 100)
            if (Player.controlDown)
            {
                if (TeamHealAccessoryEquipped = true)
                {
                        if (Potency >= 10)
                        {
                                        Potency -= 4;
                                        Player.lifeRegen += 35;
                        Player.GetDamage(DamageClass.Generic) -= 0.75f;
                        Player.moveSpeed -= 1.0f;

                        //Main.NewText("Down");
                        var Player2 = Main.player[Main.myPlayer];
                        if (Player != Player2 && Player.miscCounter % 10 == 0)
                        {
                            if (Player2.team == Player.team && Player.team != 0)
                            {
                                var local = Player.position.X - Player2.position.X;
                                var distance = (float)(Player.position.Y - Player2.position.Y);
                               // if (Math.Sqrt(local * local + (double)distance * (double)distance) < 800.0)
                               // {
                                    Player2.lifeRegen += 40;
                              //  }
                            }
                        }
                    }
                }
                // Potency -= 15;
            }
            // else PotencyAbsorbDown = true;


                //Player.lifeRegen += 50;
               
            

        }



    }
}