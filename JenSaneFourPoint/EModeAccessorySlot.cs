using Terraria;
using Terraria.ModLoader;

namespace JenSaneFourPoint
{
    public class EModeAccessorySlot : ModAccessorySlot
    {
        public override bool IsEnabled()
        {
            return Player.GetModPlayer<ExamplePlayer>().ExtraPactSlot;
        }
    }
}