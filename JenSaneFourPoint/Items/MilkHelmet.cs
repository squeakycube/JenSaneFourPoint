using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class MilkHood : ModItem
	{
			public override void SetStaticDefaults() {
            Tooltip.SetDefault("Boost minion damage by 140% but removes a minion and decreases other damage by 20%.");
        }

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Yellow;
			Item.defense = 7;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<MilkRobes>();
		}

		public override void UpdateArmorSet(Player player) {
            player.GetDamage(DamageClass.Magic) -= 0.2f;
            player.GetDamage(DamageClass.Ranged) -= 0.2f;
            player.GetDamage(DamageClass.Melee) -= 0.2f;


            player.setBonus += player.GetDamage(DamageClass.Summon) += 0.5f;
			player.GetDamage(DamageClass.Summon) += 1.4f;
            player.maxMinions += 1;
		}
    }
}