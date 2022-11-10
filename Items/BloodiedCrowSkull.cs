using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Items
{
    //[AutoloadEquip(EquipType.AccessorySlot)]
    public class BloodiedCrowSkull : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Gives more minions...at a cost.");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 10000;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Summon) -= 0.15f;
            player.maxMinions += 1;
        }

     //       player.minionDamage -= 0.2f;
   //         player.maxMinions += 1;
 //       }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "CrowSkull", 5);
            recipe.AddIngredient(ItemID.SoulofFlight, 15);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}