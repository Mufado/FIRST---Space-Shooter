public class ShieldPowerup : BasePowerup
{
    public override void ApplyPowerup(Player player)
    {
        player.IsShieldActive = true;
    }
}
