using src.Wrapper;

namespace test.Wrapper;

public class DummyClock : IClock
{
    public DateTime Now()
    {
        throw new NotImplementedException();
    }
}
