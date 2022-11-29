using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

public class DashPlayerWings : ModPlayer
{
    public const int DashDown = 0;
    public const int DashUp = 1;
    public const int DashRight = 2;
    public const int DashLeft = 3;

    public const int DashCooldown = 50; // Time (frames) between starting dashes. If this is shorter than DashDuration you can start a new dash before an old one has finished
    public const int DashDuration = 35; // Duration of the dash afterimage effect in frames

    public const float DashVelocity = 12.5f;

    // The direction the player has double tapped.  Defaults to -1 for no dash double tap
    public int DashDir = -1;

    // The fields related to the dash accessory
    public bool DashAccessoryEquipped;
    public int DashDelay = 0; // frames remaining till we can dash again
    public int DashTimer = 0; // frames remaining in the dash

    public override void ResetEffects()
    {
        // Reset our equipped flag. If the accessory is equipped somewhere, ExampleShield.UpdateAccessory will be called and set the flag before PreUpdateMovement
        DashAccessoryEquipped = false;

        if (Player.controlDown && Player.releaseDown && Player.doubleTapCardinalTimer[DashDown] < 15)
        {
            DashDir = DashDown;
        }
        else if (Player.controlUp && Player.releaseUp && Player.doubleTapCardinalTimer[DashUp] < 15)
        {
            DashDir = DashUp;
        }
        else if (Player.controlRight && Player.releaseRight && Player.doubleTapCardinalTimer[DashRight] < 15)
        {
            DashDir = DashRight;
        }
        else if (Player.controlLeft && Player.releaseLeft && Player.doubleTapCardinalTimer[DashLeft] < 15)
        {
            DashDir = DashLeft;
        }
        else
        {
            DashDir = -1;
        }
    }

    public override void PreUpdateMovement()
    {
        // if the player can use our dash, has double tapped in a direction, and our dash isn't currently on cooldown
        if (CanUseDash() && DashDir != -1 && DashDelay == 0)
        {
            Vector2 newVelocity = Player.velocity;

            switch (DashDir)
            {
                // Only apply the dash velocity if our current speed in the wanted direction is less than DashVelocity
                case DashUp when Player.velocity.Y > -DashVelocity:
                case DashDown when Player.velocity.Y < DashVelocity:
                    {
                        float dashDirection = DashDir == DashDown ? 1 : -1.3f;
                        newVelocity.Y = dashDirection * DashVelocity;
                        break;
                    }
                case DashLeft when Player.velocity.X > -DashVelocity:
                case DashRight when Player.velocity.X < DashVelocity:
                    {
                        // X-velocity is set here
                        float dashDirection = DashDir == DashRight ? 1 : -1;
                        newVelocity.X = dashDirection * DashVelocity;
                        break;
                    }
                default:
                    return; // not moving fast enough, so don't start our dash
            }

            // start our dash
            DashDelay = DashCooldown;
            DashTimer = DashDuration;
            Player.velocity = newVelocity;

        }

        if (DashDelay > 0)
            DashDelay--;

        if (DashTimer > 0)
        { 
            Player.eocDash = DashTimer;
            Player.armorEffectDrawShadowEOCShield = true;

            DashTimer--;
        }
    }

    private bool CanUseDash()
    {
        return DashAccessoryEquipped
            && !Player.setSolar // player isn't wearing solar armor
            && !Player.mount.Active; // player isn't mounted, since dashes on a mount look weird
    }
}