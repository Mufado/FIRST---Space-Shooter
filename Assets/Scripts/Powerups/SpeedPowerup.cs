public class SpeedPowerup : BasePowerup
{
    public override void ApplyPowerup(Player player)
    {
        player.speed = PowerupSettings.Instance.NewSpeed;
    }
}
