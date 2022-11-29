using JenSaneFourPoint.NPCs;
using System;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace JenSaneFourPoint.Systems;

public class TravelingMerchantSystem : ModSystem
{
    public override void PreUpdateWorld()
    {
        PlagueDoctor.UpdateTravelingMerchant();
    }

    public override void SaveWorldData(TagCompound tag)
    {
        if (PlagueDoctor.spawnTime != double.MaxValue)
        {
            tag["PlagueDoctorSpawnTime"] = PlagueDoctor.spawnTime;
        }
    }

    public override void LoadWorldData(TagCompound tag)
    {
        if (!tag.TryGet("PlagueDoctorSpawnTime", out PlagueDoctor.spawnTime))
        {
            PlagueDoctor.spawnTime = double.MaxValue;
        }
    }
}