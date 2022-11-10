using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace JenSaneFourPoint
{
	public class DashPlayer : ModPlayer { 
    // These indicate what direction is what in the timer arrays used
    public const int DashDown = 0;
    public const int DashUp = 1;
    public const int DashRight = 2;
    public const int DashLeft = 3;

    public const int DashCooldown = 50; // Time (frames) between starting dashes. If this is shorter than DashDuration you can start a new dash before an old one has finished
    public const int DashDuration = 35; // Duration of the dash afterimage effect in frames

    // The initial velocity.  10 velocity is about 37.5 tiles/second or 50 mph
    public const float DashVelocity = 10f;

    // The direction the player has double tapped.  Defaults to -1 for no dash double tap
    public int DashDir = -1;

    // The fields related to the dash accessory
    public bool CloakAccessoryEquipped;
    public int DashDelay = 0; // frames remaining till we can dash again
    public int DashTimer = 0; // frames remaining in the dash

    public override void ResetEffects()
    {
        // Reset our equipped flag. If the accessory is equipped somewhere, ExampleShield.UpdateAccessory will be called and set the flag before PreUpdateMovement
        CloakAccessoryEquipped = false;

        // ResetEffects is called not long after player.doubleTapCardinalTimer's values have been set
        // When a directional key is pressed and released, vanilla starts a 15 tick (1/4 second) timer during which a second press activates a dash
        // If the timers are set to 15, then this is the first press just processed by the vanilla logic.  Otherwise, it's a double-tap
        if (Player.controlDown && Player.releaseDown && Player.doubleTapCardinalTimer[DashDown] < 15)
        {
           // DashDir = DashDown;
               // Player.AddBuff(BuffID.Shimmering, 600); //UNCHECK THIS WHEN 1.4.4
            }
        else
        {
            DashDir = -1;
        }
    }


    private bool CanUseDash()
    {
        return CloakAccessoryEquipped
            && Player.dashType == 0 // player doesn't have Tabi or EoCShield equipped (give priority to those dashes)
            && !Player.setSolar // player isn't wearing solar armor
            && !Player.mount.Active; // player isn't mounted, since dashes on a mount look weird
    }
}
}