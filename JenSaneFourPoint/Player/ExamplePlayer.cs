using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace JenSaneFourPoint
{
    public class ExamplePlayer : ModPlayer
    {
        public bool damageReduction;
        public bool CloakAccessoryEquipped;
        public bool LifeStealOn;
        public bool MilkGodRelic;
        public bool AccAdd;
        public bool InsaneMode;
        public bool ThomasAltarDestroyed;

        public int KillCount;
        public int RefKillCount;

        public bool lifeRegenDebuff;

        public override void ResetEffects()
        {
            damageReduction = false;
            LifeStealOn = false;
            MilkGodRelic = false;
            AccAdd = true;
            //MutantsPactSlot = false;
            InsaneMode = false;
            ThomasAltarDestroyed = false;
            lifeRegenDebuff = false;
        }

        public override void UpdateBadLifeRegen()
        {
            if (this.lifeRegenDebuff)
            {
                // These lines zero out any positive lifeRegen. This is expected for all bad life regeneration effects
                // Player.lifeRegenTime uses to increase the speed at which the player reaches its maximum natural life regeneration
                // So we set it to 0, and while this debuff is active, it never reaches it
                Player.lifeRegenTime = 0;
                // lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 8 life lost per second
                Player.lifeRegen -= 16;
            }
        }


        public bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref string deathText)
        {
            if (this.damageReduction && damage > 350)
                if (Main.rand.Next(8) == 1)
                    damage = 350;
            Player.NinjaDodge();
            damage = 0;

            return true;


            if (MilkGodRelic = true)
            {

                Player.endurance += 0.3f;
            }

        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit) //Put this in example player and check if player has the buff and if they do then activate the code
        {
            if (LifeStealOn = true)
            {
                if (Main.rand.Next(10) == 1)
                {
                    int lifeSteal = 20;
                    Player.statLife += lifeSteal;
                    Player.HealEffect(lifeSteal);
                }
            }
        }

        public override void SaveData(TagCompound tag)
        {
            var playerData = new List<string>();
        //    if (InsaneMode) playerData.Add("InsaneMode");
            if (ExtraPactSlot) playerData.Add("ExtraPactSlot");
            tag.Add($"{Mod.Name}.{Player.name}.Data", playerData);
        }

        public override void LoadData(TagCompound tag)
        {
            var playerData = tag.GetList<string>($"{Mod.Name}.{Player.name}.Data");
            ExtraPactSlot = playerData.Contains("ExtraPactSlot");
           // InsaneMode = playerData.Contains("InsaneMode");

            //   disabledToggles = tag.GetList<string>($"{Mod.Name}.{Player.name}.TogglesOff");
        }

        public bool ExtraPactSlot;






        public override void PostUpdateEquips() //ThornAccessoryEquipped
        {
            if (InsaneMode = true)
            {
             //   Player.endurance -= 0.05f;
            }
        }
    //Extra Accessory Slots
    //    if (AccAdd = true)
    //        {

    //     }



    /*  public override void SaveData(TagCompound tag)
      {
          var playerData = new List<string>();
          if (InsaneMode) playerData.Add("InsaneMode");
          tag.Add($"{Mod.Name}.{Player.name}.Data", playerData);
      }

      public override void LoadData(TagCompound tag)
      {
          var playerData = tag.GetList<string>($"{Mod.Name}.{Player.name}.Data");
          InsaneMode = playerData.Contains("InsaneMode");

          //   disabledToggles = tag.GetList<string>($"{Mod.Name}.{Player.name}.TogglesOff");
      } */

}
}
