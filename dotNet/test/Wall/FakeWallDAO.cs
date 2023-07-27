using System.Collections.Immutable;
using src.Wall;

namespace test.Wall;

public class FakeWallDAO : IWallDAO
{
    private readonly List<Brick> _wall = new();

    public ImmutableArray<Brick> GetBricks(src.User.User user)
    {
        return _wall.ToImmutableArray();
    }

    public void AddBrick(src.User.User user, Brick brick)
    {
        _wall.Add(brick);
    }
}
