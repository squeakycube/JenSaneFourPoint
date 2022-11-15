using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using System;
using System.Collections.Generic;
using Terraria.GameInput;

namespace JenSaneFourPoint.Items.PR
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Legs value here will result in TML expecting a X_Legs.png file to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Legs)]
    public class PlaugePants : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Boosts plauge damage by 25% and potency regeneration.");
        }

        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
            Item.rare = ItemRarityID.Green; // The rarity of the item
            Item.defense = 7; // The amount of defense the item will give when equipped
        }

        public override void UpdateEquip(Player player)
        {
            PlaugeReal p = player.GetModPlayer<PlaugeReal>();
            p.PlaugeSet3Equipped = true;
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
    }
}