using JenSaneFourPoint.NPCs;
using System;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace JenSaneFourPoint.Systems;

public class TravelingMerchantSystem : ModSystem
{
    public override void PreUpdateWorld()
    {
        PlaugeDoctor.UpdateTravelingMerchant();
    }

    public override void SaveWorldData(TagCompound tag)
    {
        if (PlaugeDoctor.spawnTime != double.MaxValue)
        {
            tag["PlaugeDoctorSpawnTime"] = PlaugeDoctor.spawnTime;
        }
    }

    public override void LoadWorldData(TagCompound tag)
    {
        if (!tag.TryGet("PlaugeDoctorSpawnTime", out PlaugeDoctor.spawnTime))
        {
            PlaugeDoctor.spawnTime = double.MaxValue;
        }
    }
}