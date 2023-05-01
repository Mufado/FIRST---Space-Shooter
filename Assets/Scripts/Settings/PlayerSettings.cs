public class PlayerSettings
{
    private static PlayerSettings _instance;

    public float Speed { get; }
    public int Lives { get; }
    public float FireRate { get; }
    public int CollisionDamage { get; }
    public float LeftBound { get; }
    public float RightBound { get; }
    public float TopBound { get; }
    public float BottomBound { get; }
    public float MuzzlePosition { get; }

    public static PlayerSettings Instance
    {
        get
        {
            if (_instance == null) _instance = new PlayerSettings();
            return _instance;
        }
    }

    private PlayerSettings()
    {
        Speed = 10f;
        Lives = 3;
        FireRate = 0.2f;
        CollisionDamage = 10;
        LeftBound = -9.24f;
        RightBound = 9.24f;
        TopBound = 4.98f;
        BottomBound = -4.98f;
        MuzzlePosition = 1f;
    }
}
