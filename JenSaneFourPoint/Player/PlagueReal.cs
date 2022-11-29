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
    public class PlagueReal : ModPlayer
    {
        // These indicate what direction is what in the timer arrays used

        public int Potency = 0;
        public int PotencyConsume = 0;
        public int PotencyMax = 1000;
        public int PotencyRegen = 1;
        public bool InHealDistance;

        public bool TeamHealAccessoryEquipped;//            TeamHealAccessoryEquipped = false;
        public bool MassMaxHealAccessoryEquipped;
        public bool CloakAccessoryEquipped; //This should be skull, change it later
        public bool MedBagEquipped; //For med supplies and sigil
        public bool PlagueSet1Equipped;
        public bool PlagueSet2Equipped;
        public bool PlagueSet3Equipped; //PlagueRegenItemEquipped
        public bool PlagueRegenItemEquipped;
        public bool PlagueRegenMoonLordEquipped;
        public bool MushroomSet1Equipped;
        public bool MushroomSet2Equipped;
        public bool MushroomSet3Equipped;
        public bool ThornAccessoryEquipped;
        public int surgicalint = 30;
        public int HPRegen = 30;
        //if (this.MedBagEquipped)
        public bool SkullHeartRegenIncrease;
        public bool LesserPlagueRegenItemEquipped;
        public bool WeDontLikeThomas;
        public bool MLPlagueSet1Equipped;
        public bool MLPlagueSet2Equipped;
        public bool MLPlagueSet3Equipped;
        public bool PlagueCause;
        public bool PlagueRegenPotion;

        public bool healingPrefix;

        public bool InsaneMode;

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
                if (this.MedBagEquipped)
                {
                    if (this.MassMaxHealAccessoryEquipped)
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


            // Potency -= 15;

        }


        public override void ResetEffects()
        {
            TeamHealAccessoryEquipped = false;
            InHealDistance = false;
            MassMaxHealAccessoryEquipped = false;
            CloakAccessoryEquipped = false;
            MedBagEquipped = false;
            PlagueSet1Equipped = false;
            PlagueSet2Equipped = false;
            PlagueSet3Equipped = false;
            PlagueRegenItemEquipped = false;
            PlagueRegenMoonLordEquipped = false;
            MushroomSet1Equipped = false;
            MushroomSet2Equipped = false;
            MushroomSet3Equipped = false; //ThornAccessoryEquipped
            ThornAccessoryEquipped = false;
            SkullHeartRegenIncrease = false;
            LesserPlagueRegenItemEquipped = false;
            WeDontLikeThomas = false;
            MLPlagueSet1Equipped = false;
            MLPlagueSet2Equipped = false;
            MLPlagueSet3Equipped = false;
            PlagueCause = false;
            PlagueRegenPotion = false;
        }




        public override void PostUpdateEquips() //ThornAccessoryEquipped
        {


            if (this.MedBagEquipped) //skullen heart buffed
            {
                if (this.SkullHeartRegenIncrease)
                {
                    HPRegen = 65;
                }
            }

            if (this.MedBagEquipped) //Potency regeneration potion
            {
                if (this.PlagueRegenPotion)
                {
                    if (Potency >= 100)
                    {
                        if (Potency < PotencyMax)
                        {
                            if (Main.rand.Next(10) == 1)
                            {
                                Potency += 1;
                            }
                        }
                    }
                }
            }

            if (JenSaneFourPoint.TeamRegenVer2.Current) //WeDontLikeThomas
            {
                if (this.MedBagEquipped)
                {
                    if (Potency >= 10)
                    {
                        //if (CloakAccessoryEquipped = true)
                        if (this.CloakAccessoryEquipped)
                        //if (this.MedBagEquipped)
                        {
                            Player.controlUseItem = false;
                            Potency -= 4;
                            Player.lifeRegen += HPRegen;
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
                                    Player2.lifeRegen += HPRegen;
                                }
                            }
                        }
                    }
                }
            }


            if (JenSaneFourPoint.TeamRegenVer2.Current) //WeDontLikeThomas
            {
                        if (this.WeDontLikeThomas)
                        {
                            Player.lifeRegen -= 55;

                            var Player2 = Main.player[Main.myPlayer];
                            if (Player != Player2 && Player.miscCounter % 10 == 0)
                            {
                                if (Player2.team == Player.team && Player.team != 0)
                                {
                                    var local = Player.position.X - Player2.position.X;
                                    var distance = (float)(Player.position.Y - Player2.position.Y);
                            Player2.lifeRegen -= 55;
                        }
                    }
                }
            }


            if (this.MedBagEquipped) //Normal med bag potency regen
            {
                if (Potency >= 100)
                {
                    if (Potency < PotencyMax)
                    {
                        if (Main.rand.Next(16) == 1)
                        {
                            Potency += 1;
                        }
                    }
                }
                else
                {
                    Player.moveSpeed -= 0.5f;
                    if (Main.rand.Next(20) == 1)
                    {
                        Potency += 1;
                    }
                }
            }

            if (this.MedBagEquipped) //Faster potency regen if not moving
            {
                if (Potency < PotencyMax)
                {
                    if (Player.velocity.X == 0)
                    {
                        if (Main.rand.Next(16) == 1)
                        {
                            Potency += 1;
                        }
                    }
                }
            }

            if (this.MedBagEquipped) //Potency Charm
            {
                if (PlagueRegenItemEquipped = true)
                {
                    Player.GetDamage(DamageClass.Generic) -= 0.75f;
                    Player.GetDamage(ModContent.GetInstance<PlagueDoctorDamageClass>()) += 0.75f;

                    if (Potency < PotencyMax)
                    {
                        if (Main.rand.Next(16) == 1)
                        {
                            Potency += 1;
                        }
                    }
                }
            }

            if (this.MedBagEquipped) //Fractured Moon Lord Heart
            {
                if (PlagueRegenMoonLordEquipped = true)
                {
                    Player.GetDamage(ModContent.GetInstance<PlagueDoctorDamageClass>()) += 0.35f;

                    if (Potency < PotencyMax)
                    {
                        if (Main.rand.Next(15) == 1)
                        {
                            Potency += 1;
                        }
                    }
                }
            }

            if (this.MedBagEquipped) //Urine o milk god
            {
                if (LesserPlagueRegenItemEquipped = true)
                {
                    if (Potency < PotencyMax)
                    {
                        if (Main.rand.Next(16) == 1)
                        {
                            Potency += 1;
                        }
                    }
                }
            }



            //healing bag team regen
            if (this.MedBagEquipped)
            {
                Player.lifeRegen += 1;
                var Player2 = Main.player[Main.myPlayer];
                if (Player != Player2 && Player.miscCounter % 10 == 0)
                {
                    if (Player2.team == Player.team && Player.team != 0)
                    {
                        var local = Player.position.X - Player2.position.X;
                        var distance = (float)(Player.position.Y - Player2.position.Y);
                        if (Math.Sqrt(local * local + (double)distance * (double)distance) < 800.0)
                        {
                            // player2.AddBuff(43, 20, true);
                            Player2.lifeRegen += 2;
                        }
                    }
                }
            }


            if (this.MedBagEquipped) //Plague Set
            {
                if (Potency < PotencyMax)
                {
                    {
                        if (this.PlagueSet1Equipped)
                        {
                            if (MedBagEquipped = true)
                            {
                                if (Main.rand.Next(20) == 1)
                                {
                                    Potency += 1;
                                }
                                Player.GetDamage(ModContent.GetInstance<PlagueDoctorDamageClass>()) += 0.45f;
                                Player.GetDamage(DamageClass.Generic) -= 0.3f;

                            }
                            Player.setBonus += Player.GetDamage(ModContent.GetInstance<PlagueDoctorDamageClass>()) += 0.25f;
                        }
                    }

                    if (this.MedBagEquipped)
                    {
                        if (this.PlagueSet2Equipped)
                        {
                            if (MedBagEquipped = true)
                            {
                                if (Main.rand.Next(20) == 1)
                                {
                                    Potency += 1;
                                }
                            }
                            Player.GetDamage(ModContent.GetInstance<PlagueDoctorDamageClass>()) += 0.25f;
                        }
                    }

                    if (this.MedBagEquipped)
                    {
                        if (this.PlagueSet3Equipped)
                        {
                            if (MedBagEquipped = true)
                            {
                                if (Main.rand.Next(20) == 1)
                                {
                                    Potency += 1;
                                }
                            }
                            Player.GetDamage(ModContent.GetInstance<PlagueDoctorDamageClass>()) += 0.25f;
                        }
                    }
                }

            }

            if (this.MedBagEquipped) //Post moon lord plague set
            {
                if (Potency < PotencyMax)
                {
                    {
                        if (this.MLPlagueSet1Equipped)
                        {
                            if (MedBagEquipped = true)
                            {
                                if (Main.rand.Next(10) == 1)
                                {
                                    Potency += 1;
                                }
                                Player.GetDamage(ModContent.GetInstance<PlagueDoctorDamageClass>()) += 0.95f;
                                Player.GetDamage(DamageClass.Generic) -= 0.3f;

                            }
                            Player.setBonus += Player.GetDamage(ModContent.GetInstance<PlagueDoctorDamageClass>()) += 1.25f;
                        }
                    }

                    if (this.MedBagEquipped)
                    {
                        if (this.MLPlagueSet2Equipped)
                        {
                            if (MedBagEquipped = true)
                            {
                                if (Main.rand.Next(10) == 1)
                                {
                                    Potency += 1;
                                }
                            }
                            Player.GetDamage(ModContent.GetInstance<PlagueDoctorDamageClass>()) += 0.75f;
                        }
                    }

                    if (this.MedBagEquipped)
                    {
                        if (this.MLPlagueSet3Equipped)
                        {
                            if (MedBagEquipped = true)
                            {
                                if (Main.rand.Next(10) == 1)
                                {
                                    Potency += 1;
                                }
                            }
                            Player.GetDamage(ModContent.GetInstance<PlagueDoctorDamageClass>()) += 0.75f;
                        }
                    }
                }
            }

                if (this.MedBagEquipped) //Mushroom Set
            {
                if (Potency < PotencyMax)
                {
                    {
                        if (this.MushroomSet1Equipped)
                        {
                            if (MedBagEquipped = true)
                            {
                                if (Main.rand.Next(23) == 1)
                                {
                                    Potency += 1;
                                }
                                Player.GetDamage(ModContent.GetInstance<PlagueDoctorDamageClass>()) += 0.1f;

                            }
                            Player.setBonus += Player.GetDamage(ModContent.GetInstance<PlagueDoctorDamageClass>()) += 0.1f;
                        }
                    }

                    if (this.MedBagEquipped)
                    {
                        if (this.MushroomSet2Equipped)
                        {
                            if (MedBagEquipped = true)
                            {
                                if (Main.rand.Next(23) == 1)
                                {
                                    Potency += 1;
                                }
                            }
                            Player.GetDamage(ModContent.GetInstance<PlagueDoctorDamageClass>()) += 0.1f;
                        }
                    }

                    if (this.MedBagEquipped)
                    {
                        if (this.MushroomSet3Equipped)
                        {
                            if (MedBagEquipped = true)
                            {
                                if (Main.rand.Next(23) == 1)
                                {
                                    Potency += 1;
                                }
                            }
                            Player.GetDamage(ModContent.GetInstance<PlagueDoctorDamageClass>()) += 0.1f;
                        }
                    }
                }

            }

        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit) //Put this in example player and check if player has the buff and if they do then activate the code
        {
            if (PlagueCause = true)
            {
                if (Main.rand.Next(2) == 1)
                {
                    target.AddBuff(BuffID.Poisoned, 30);
                }
            }
        }





    }
        
}