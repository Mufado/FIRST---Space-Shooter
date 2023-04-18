public class TripleLaserSettings
{
    private static TripleLaserSettings _instance;

    public int Damage { get; }
    public float Speed { get; }

    public static TripleLaserSettings Instance
    {
        get { return _instance == null ? new TripleLaserSettings() : _instance; }
    }

    public TripleLaserSettings()
    {
        Damage = 1;
        Speed = 20f;
    }
}
