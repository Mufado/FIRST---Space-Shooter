public class SpeedPowerup : BasePowerup
{
    private float _newPlayerSpeed = PowerupSettings.Instance.NewSpeed;

    public override void ApplyPowerup(Player player)
    {
        player.speed = _newPlayerSpeed;
    }
}
