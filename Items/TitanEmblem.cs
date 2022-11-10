using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Items
{
    //[AutoloadEquip(EquipType.AccessorySlot)]
    public class TitanEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Grants large amounts of health but decreases damage.");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 10000;
            Item.rare = ItemRarityID.Purple;
            Item.accessory = true;
            Item.defense = 10;


        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) -= 0.75f;
            player.statLifeMax2 *= 2;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ShinyStone, 1);
            recipe.AddIngredient(ItemID.SporeSac, 1);
            recipe.AddIngredient(ItemID.DestroyerEmblem, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
           // recipe.AddRecipe(); //Ankh Shield Destroyer Emblem
        }
    }
}
