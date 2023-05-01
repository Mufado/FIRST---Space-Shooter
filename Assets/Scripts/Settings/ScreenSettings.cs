public class ScreenSettings
{
    private static ScreenSettings _instance;

    public float LeftBound { get; }
    public float RightBound { get; }
    public float TopBound { get; }
    public float BottomBound { get; }

    public static ScreenSettings Instance
    {
        get
        {
            if (_instance == null) _instance = new ScreenSettings();
            return _instance;
        }
    }

    private ScreenSettings()
    {
        LeftBound = -9.24f;
        RightBound = 9.24f;
        TopBound = 4.98f;
        BottomBound = -4.98f;
    }
}
