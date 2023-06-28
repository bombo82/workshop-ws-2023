namespace SocialNetworkTest.Wall;

public class StubClock : IClock
{
    public DateTime now()
    {
        return new DateTime(0);
    }
}
