public class TripleLaser : BaseGun
{
    private void Start()
    {
        damage = TripleLaserSettings.Instance.Damage;
        speed = TripleLaserSettings.Instance.Speed;
    }

    private void Update()
    {
        Moves();

        LimitMoves();
    }
}
