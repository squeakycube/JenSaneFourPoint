using Terraria;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Prefixes
{
    // This class serves as an example for declaring item 'prefixes', or 'modifiers' in other words.
    public class Surgical : ModPrefix
    {
        // We declare a custom *virtual* property here, so that another type, ExampleDerivedPrefix, could override it and change the effective power for itself.
        public virtual float Power => 1f;

        // Change your category this way, defaults to PrefixCategory.Custom. Affects which items can get this prefix.
        public override PrefixCategory Category => PrefixCategory.Accessory;

        // See documentation for vanilla weights and more information.
        // In case of multiple prefixes with similar functions this can be used with a switch/case to provide different chances for different prefixes
        // Note: a weight of 0f might still be rolled. See CanRoll to exclude prefixes.
        // Note: if you use PrefixCategory.Custom, actually use ModItem.ChoosePrefix instead.
        public override float RollChance(Item item)
        {
            return 1f;
        }

        // Determines if it can roll at all.
        // Use this to control if a prefix can be rolled or not.
        public override bool CanRoll(Item item)
        {
            return true;
        }

        // Use this function to modify these stats for items which have this prefix:
        // Damage Multiplier, Knockback Multiplier, Use Time Multiplier, Scale Multiplier (Size), Shoot Speed Multiplier, Mana Multiplier (Mana cost), Crit Bonus.

        // Modify the cost of items with this modifier with this function.
        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 1f + 0.05f * Power;
        }

        // This is used to modify most other stats of items which have this modifier.
        public override void Apply(Item item)
        {
            //
            //player.GetDamage(DamageClass.Generic) += 3f;
            //item.defense += 4;

            var modPlayer = Main.LocalPlayer.GetModPlayer<PlaugeReal>(); //        public int PotencyCost = 30;
            if (modPlayer.Potency < modPlayer.PotencyMax)
                if (Main.rand.Next(4) == 1)
                modPlayer.Potency += 1;




        }


        public void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            player.lifeRegenTime = 0;
            player.lifeRegen += 100;

        }
    }
    }
