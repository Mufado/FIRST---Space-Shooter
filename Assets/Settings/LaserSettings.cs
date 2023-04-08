public class LaserSettings
{
    private static LaserSettings _instance;

    public int Damage { get; }
    public float Speed { get; }
    public float Bound { get; }

    public static LaserSettings Instance
    {
        get { return _instance == null ? new LaserSettings() : _instance; }
    }

    public LaserSettings()
    {
        Damage = 1;
        Speed = 20f;
        Bound = 8f;
    }
}
