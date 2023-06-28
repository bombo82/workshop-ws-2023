using System.Collections.Immutable;

namespace src.Wall;

public interface IWallDAO
{
    ImmutableArray<Brick> GetBricks(User.User user);
    void AddBrick(User.User user, Brick brick);
}
