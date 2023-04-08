public class EnemySettings
{
    private static EnemySettings _instance;

    public float Speed { get; }
    public int Lives { get; }
    public int CollisionDamage { get; }
    public float LeftBound { get; }
    public float RightBound { get; }
    public float TopBound { get; }
    public float BottomBound { get; }

    public static EnemySettings Instance
    {
        get { return _instance == null ? new EnemySettings() : _instance; }
    }

    private EnemySettings()
    {
        Speed = 5f;
        Lives = 1;
        CollisionDamage = 1;
        LeftBound = -9.3f;
        RightBound = 9.3f;
        TopBound = 7f;
        BottomBound = -7f;
    }
}
