using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Items
{
    public class DryadLeaf : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Gives Dryads Blessing");
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
            Item.rare = ItemRarityID.Green;
            Item.value = 1000000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(BuffID.DryadsWard, 3);
        }
    }
}


