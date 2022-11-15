using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Items
{
    [AutoloadEquip(EquipType.Wings)]
    public class ExampleWings : ModItem //Raven Queen's wings (low drop from ravens)
    {
        // To see how this config option was added, see ExampleModConfig.cs

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("This is a dev wing set.");
            DisplayName.SetDefault("Raven Queen's Wings");

            // These wings use the same values as the solar wings
            // Fly time: 180 ticks = 3 seconds
            // Fly speed: 9
            // Acceleration multiplier: 2.5
            ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(180, 9f, 2.5f);
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 20;
            Item.value = 10000;
            Item.rare = ItemRarityID.Purple;
            Item.accessory = true;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.85f; // Falling glide speed
            ascentWhenRising = 0.15f; // Rising speed
            maxCanAscendMultiplier = 1f;
            maxAscentMultiplier = 3f;
            constantAscend = 0.135f;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            DashPlayerWings p = player.GetModPlayer<DashPlayerWings>();
            p.DashAccessoryEquipped = true;
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
    }
}