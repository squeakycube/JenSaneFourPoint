using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Items
{
    public class TheMilkGodBlood : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The blessed milk god has blessed us with this liquid"
                + "\nHeals both the spirit and body");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 30;
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
            Item.healLife = 175; // While we change the actual healing value in GetHealLife, item.healLife still needs to be higher than 0 for the item to be considered a healing item
            Item.potion = true; // Makes it so this item applies potion sickness on use and allows it to be used with quick heal
            Item.value = Item.buyPrice(gold: 1000);
        }

        public override void GetHealLife(Player player, bool quickHeal, ref int healValue)
        {
            // Make the item heal half the player's max health normally, or one fourth if used with quick heal
            healValue = player.statLifeMax2 / (quickHeal ? 4 : 2);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GreaterHealingPotion, 15);
            recipe.AddIngredient(ItemID.Bone, 50);
            recipe.AddIngredient(ItemID.SoulofMight, 15);
            recipe.AddIngredient(ItemID.SoulofSight, 15);
            recipe.AddIngredient(ItemID.SoulofFright, 15);
            // recipe.AddIngredient(Mod, "SoulOfBlight", 15); //Super Healing Potion
            recipe.AddIngredient(Mod, "SoulOfBlight", 15); //TheMilkGodBlood
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}