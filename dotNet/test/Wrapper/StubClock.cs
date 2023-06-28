using src.Wrapper;

namespace test.Wrapper;

public class StubClock : IClock
{
    public DateTime Now()
    {
        return new DateTime(0);
    }
}
