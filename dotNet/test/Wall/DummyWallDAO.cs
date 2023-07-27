using System.Collections.Immutable;
using src.Wall;

namespace test.Wall;

public class DummyWallDAO : IWallDAO
{
    public ImmutableArray<Brick> GetBricks(src.User.User user)
    {
        throw new NotImplementedException();
    }

    public void AddBrick(src.User.User user, Brick brick)
    {
        throw new NotImplementedException();
    }
}
