using src.User;
using src.Wall;

namespace SocialNetworkTest.Wall;

public interface IWallDAO
{
    List<Brick> GetBricks(User user);
    void AddBrick(User user, Brick brick);
}
