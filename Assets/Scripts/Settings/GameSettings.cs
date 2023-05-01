public class GameSettings
{
    private static GameSettings _instance;

    public float DefaultBulletBound { get; }
    public int DeathThreshold { get; }

    public static GameSettings Instance
    {
        get
        {
            if (_instance == null) _instance = new GameSettings();
            return _instance;
        }
    }

    private GameSettings()
    {
        DeathThreshold = 0;
        DefaultBulletBound = 8f;
    }
}
