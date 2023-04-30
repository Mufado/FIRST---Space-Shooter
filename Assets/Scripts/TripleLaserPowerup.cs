public class TripleLaserPowerup : BaseAmmoPowerup
{
    public override void ApplyPowerup(Player player)
    {
        player.ammoPrefab = newAmmoPrefab;
    }
}
