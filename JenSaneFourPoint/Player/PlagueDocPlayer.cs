using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExampleMod.Content.DamageClasses
{
	public class ExampleDamageClass : DamageClass
	{
        public override StatInheritanceData GetModifierInheritance(DamageClass Plague)
        {
            if (Plague == DamageClass.Generic)
                return StatInheritanceData.Full;

            return new StatInheritanceData(
                damageInheritance: 0f,
                critChanceInheritance: 0f,
                attackSpeedInheritance: 0f,
                armorPenInheritance: 0f,
                knockbackInheritance: 0f
            );
        }
        public override bool UseStandardCritCalcs => true;

		public override bool ShowStatTooltipLine(Player player, string lineName) {
			if (lineName == "Speed")
				return false;

			return true;
		}
	}
}