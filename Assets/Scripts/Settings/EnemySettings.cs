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
    public float SpawnTime { get; }
    public int ScoreValue { get; }


    public static EnemySettings Instance
    {
        get
        {
            if (_instance == null) _instance = new EnemySettings();
            return _instance;
        }
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
        SpawnTime = 0.5f;
        ScoreValue = 10;
    }
}
