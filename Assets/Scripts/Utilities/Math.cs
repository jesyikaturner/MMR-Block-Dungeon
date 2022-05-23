

public sealed class Math
{
    private readonly Logger logger = Logger.Instance;
    private static readonly Math instance = new Math();

    private Math() { }

    public static Math Instance
    {
        get
        {
            return instance;
        }
    }
}
