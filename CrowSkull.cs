using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Items
{
    //[AutoloadEquip(EquipType.AccessorySlot)]
    public class CrowSkull : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Its pretty, isnt it? -Jennifer");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 100;
            Item.maxStack = 9999;
            // item.rare = ItemRarityID.Blue;
        }
    }
}