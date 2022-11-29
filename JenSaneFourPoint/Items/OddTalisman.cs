using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Items
{
    //[AutoloadEquip(EquipType.AccessorySlot)]
    public class OddTalisman : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("You can feel a terrible evil connected to this");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = -100;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Red;
        }
    }
}