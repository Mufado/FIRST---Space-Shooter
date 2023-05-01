public class LaserSettings
{
    private static LaserSettings _instance;

    public int Damage { get; }
    public float Speed { get; }

    public static LaserSettings Instance
    {
        get
        {
            if (_instance == null) _instance = new LaserSettings();
            return _instance;
        }
    }

    public LaserSettings()
    {
        Damage = 1;
        Speed = 20f;
    }
}
