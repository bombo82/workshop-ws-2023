using System.Collections.Immutable;
using src.Wall;

namespace test.Wall;

public class SpyWallDAO : IWallDAO
{
    public src.User.User? UserParameter { get; private set; }
    public Brick? BrickParameter { get; private set; }

    public ImmutableArray<Brick> GetBricks(src.User.User user)
    {
        return ImmutableArray.Create(new Brick("", new DateTime()));
    }

    public void AddBrick(src.User.User user, Brick brick)
    {
        UserParameter = user;
        BrickParameter = brick;
    }
}
