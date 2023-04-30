public class PowerupSettings
{
    private static PowerupSettings _instance;

    public float DefaultSpeed { get; }
    public float DefaultTopBound { get; }
    public float DefaultBottomBound { get; }
    public float DefaultLeftBound { get; }
    public float DefaultRightBound { get;  }
    public float NewSpeed { get; }

    public static PowerupSettings Instance
    {
        get { return _instance == null ? new PowerupSettings() : _instance; }
    }

    private PowerupSettings()
    {
        DefaultSpeed = 3f;
        DefaultTopBound = 7f;
        DefaultBottomBound = -7f;
        DefaultLeftBound = -9f;
        DefaultRightBound = 9f;
        NewSpeed = 15f;
    }
}
