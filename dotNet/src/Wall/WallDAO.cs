using System.Collections.Immutable;
using src.Exception;

namespace src.Wall;

public class WallDAO : IWallDAO
{
    [Obsolete]
    public static List<Brick> FindBricksByUser(src.User.User user)
    {
        throw new NotTestableCallException("WallDAO should not be invoked on an unit test.");
    }

    [Obsolete]
    public static void AddBrickToUser(src.User.User user, Brick brick)
    {
        throw new NotTestableCallException("WallDAO should not be invoked on an unit test.");
    }

    public ImmutableArray<Brick> GetBricks(User.User user)
    {
        return ImmutableArray.ToImmutableArray(FindBricksByUser(user));
    }

    public void AddBrick(User.User user, Brick brick)
    {
        AddBrickToUser(user, brick);
    }
}
