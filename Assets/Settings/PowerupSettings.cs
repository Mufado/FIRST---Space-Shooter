public class PowerupSettings
{
    private static PowerupSettings _instance;

    public float DefaultSpeed { get; }
    public float DefaultTopBound { get; set; }
    public float DefaultBottomBound { get; set; }
    public float DefaultLeftBound { get; set; }
    public float DefaultRightBound { get; set;  }

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
    }
}
