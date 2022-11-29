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

namespace JenSaneFourPoint
{
	public class JenSaneFourPoint : Mod
    {
        internal static ModKeybind MegaMassHealKey;
        internal static ModKeybind TeamDefIncrease;
        internal static ModKeybind TeamRegenVer2;

        public override void Load()
        {
            MegaMassHealKey = KeybindLoader.RegisterKeybind(this, "Mega Mass Heal", "P");
            TeamDefIncrease = KeybindLoader.RegisterKeybind(this, "TeamDefIncrease", "O");
            TeamRegenVer2 = KeybindLoader.RegisterKeybind(this, "TeamRegenVer2", "N");
            // Add certain equip textures
            //EquipLoader.AddEquipTexture(this, "JenSaneFourPoint/Items/MilkRobes_Legs", EquipType.Legs, name: "MilkRobes_Legs");
            //EquipLoader.AddEquipTexture(this, "JenSaneFourPoint/Items/MilkRobes_Legs", EquipType.Legs, name: "MilkRobes_Legs");
            //AddEquipTexture(new Items.Armor.BlockyHead(), null, EquipType.Head, "BlockyHead", "ExampleMod/Items/Armor/ExampleCostume_Head");
            //AddEquipTexture(new Items.Armor.BlockyBody(), null, EquipType.Body, "BlockyBody", "ExampleMod/Items/Armor/ExampleCostume_Body", "ExampleMod/Items/Armor/ExampleCostume_Arms");
            //AddEquipTexture(new Items.Armor.BlockyLegs(), null, EquipType.Legs, "BlockyLeg", "ExampleMod/Items/Armor/ExampleCostume_Legs");
        }

        public override void Unload()
        {
            MegaMassHealKey = null;
            TeamDefIncrease = null;
            TeamRegenVer2 = null;
        }

        public static Player PlayerExists(int whoAmI)
        {
            return whoAmI > -1 && whoAmI < Main.maxPlayers && Main.player[whoAmI].active && !Main.player[whoAmI].dead && !Main.player[whoAmI].ghost ? Main.player[whoAmI] : null;
        }

        public static Player PlayerExists(float whoAmI)
        {
            return PlayerExists((int)whoAmI);
        }

        public static NPC NPCExists(int whoAmI, params int[] types)
        {
            return whoAmI > -1 && whoAmI < Main.maxNPCs && Main.npc[whoAmI].active && (types.Length == 0 || types.Contains(Main.npc[whoAmI].type)) ? Main.npc[whoAmI] : null;
        }

        public static NPC NPCExists(float whoAmI, params int[] types)
        {
            return NPCExists((int)whoAmI, types);
        }


    }
}