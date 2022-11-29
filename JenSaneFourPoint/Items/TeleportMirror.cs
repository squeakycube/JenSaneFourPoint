using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace JenSaneFourPoint.Items
{
    internal class TeleportMirror : ModItem
    {
        private static readonly Color[] itemNameCycleColors = {
        };

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Teleports you to a random place in the world.");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.IceMirror); // Copies the defaults from the Ice Mirror.
            Item.rare = ItemRarityID.Purple;
            Item.mana = 16;
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (Main.rand.NextBool())
            {
                Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, Color.Purple, 1.1f); // Makes dust from the player's position and copies the hitbox of which the dust may spawn. Change these arguments if needed.
            }

            if (player.itemTime == 0)
            {
                player.ApplyItemTime(Item);
            }
            else if (player.itemTime == player.itemTimeMax / 2)
            {
                for (int d = 0; d < 70; d++)
                {
                    Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 150, default, 1.5f);
                }

                player.grappling[0] = -1;
                player.grapCount = 0;

                for (int p = 0; p < 1000; p++)
                {
                    if (Main.projectile[p].active && Main.projectile[p].owner == player.whoAmI && Main.projectile[p].aiStyle == 7)
                    {
                        Main.projectile[p].Kill();
                    }
                }

                player.TeleportationPotion();

                for (int d = 0; d < 70; d++)
                {
                    Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, default, 1.5f);
                }
            }
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {

            foreach (TooltipLine line2 in tooltips)
            {
                if (line2.Mod == "Terraria")
                {
                    float fade = (Main.GameUpdateCount % 60) / 60f;
                }
            }
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.MagicMirror, 1);
            recipe.AddIngredient(ItemID.TeleportationPotion, 30);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}