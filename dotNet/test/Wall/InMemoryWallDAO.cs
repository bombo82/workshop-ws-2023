using System.Collections.Immutable;
using src.Wall;

namespace test.Wall;

public class InMemoryWallDAO : IWallDAO
{
    private List<Brick> _wall = new();

    public ImmutableArray<Brick> GetBricks(src.User.User user)
    {
        return ImmutableArray.ToImmutableArray(_wall);
    }

    public void AddBrick(src.User.User user, Brick brick)
    {
        _wall.Add(brick);
    }
}
