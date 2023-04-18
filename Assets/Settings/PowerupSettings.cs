public class PowerupSettings
{
    private static PowerupSettings _instance;

    public float DefaultSpeed { get; }
    public float DefaultBound { get; set; }

    public static PowerupSettings Instance
    {
        get { return _instance == null ? new PowerupSettings() : _instance; }
    }

    private PowerupSettings()
    {
        DefaultSpeed = 3f;
        DefaultBound = -7f;
    }
}
