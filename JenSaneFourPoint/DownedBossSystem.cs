using System.Collections;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace JenSaneFourPoint
{
    public class DownedBossSystem : ModSystem
    {
        public static bool downedThomas = false;

        public override void OnWorldLoad()
        {
            downedThomas = false;
            // downedOtherBoss = false;
        }

        public override void OnWorldUnload()
        {
            downedThomas = false;
            // downedOtherBoss = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            if (downedThomas)
            {
                tag["downedThomas"] = true;
            }
        }

        public override void LoadWorldData(TagCompound tag)
        {
            downedThomas = tag.ContainsKey("downedThomas");
            // downedOtherBoss = tag.ContainsKey("downedOtherBoss");
        }

        public override void NetSend(BinaryWriter writer)
        {
            // Order of operations is important and has to match that of NetReceive
            var flags = new BitsByte();
            flags[0] = downedThomas;
            // flags[1] = downedOtherBoss;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            // Order of operations is important and has to match that of NetSend
            BitsByte flags = reader.ReadByte();
            downedThomas = flags[0];
        }




        }
}