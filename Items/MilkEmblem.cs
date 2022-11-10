using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Items
{
    //[AutoloadEquip(EquipType.AccessorySlot)]
    public class MilkEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Philbert's holy symbol. +25% melee damage -10% Melee attack speed.");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 10000;
            Item.rare = ItemRarityID.Yellow;
            Item.accessory = true;
            Item.defense = 10;


        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Melee) += 0.25f;
            player.GetAttackSpeed(DamageClass.Melee) -= 0.1f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "TitanEmblem", 1); //TheMilkGodBlood
            recipe.AddIngredient(Mod, "TheMilkGodBlood", 15); //TheMilkGodBlood
            recipe.AddIngredient(ItemID.FireGauntlet, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
           // recipe.AddRecipe(); //Ankh Shield Destroyer Emblem
        }
    }
}
