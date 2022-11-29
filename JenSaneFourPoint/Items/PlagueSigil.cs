using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System;
using JenSaneFourPoint.Buffs;

namespace JenSaneFourPoint.Items
{
	public class PlagueSigil : ModItem
	{
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 1000);
            Item.rare = ItemRarityID.Purple;
        }

        public int RefKillCount;
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("Allows the use and greater regeneration of potency. Increases life regeneration and gives life steal to teammates who are nearby. Grants immunity to Plague debuff");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            PlagueReal p = player.GetModPlayer<PlagueReal>();
            p.MedBagEquipped = true;
            player.buffImmune[ModContent.BuffType<Plague>()] = true;

            player.AddBuff(ModContent.BuffType<LifeSteal>(), 2);
            player.lifeRegen += 5;
            if (p.Potency < p.PotencyMax)
            {
                if (Main.rand.Next(4) == 1)
                    p.Potency += p.PotencyRegen;
            }
            var Player2 = Main.player[Main.myPlayer];
            if (player != Player2 && player.miscCounter % 10 == 0)
            {
                if (Player2.team == player.team && player.team != 0)
                {
                    var local = player.position.X - Player2.position.X;
                    var distance = (float)(player.position.Y - Player2.position.Y);
                    if (Math.Sqrt(local * local + (double)distance * (double)distance) < 800.0)
                    {
                        player.AddBuff(ModContent.BuffType<LifeSteal>(), 20);
                        Player2.lifeRegen += 5;
                    }
                }
            }
        }

                    public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, "PlagueEmblem", 1);
            recipe.AddIngredient(Mod, "SoulOfBlight", 15);
            recipe.AddIngredient(Mod, "CrowSkull", 5);
            recipe.AddIngredient(Mod, "PlagueDoctorMedicalSupplies", 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}