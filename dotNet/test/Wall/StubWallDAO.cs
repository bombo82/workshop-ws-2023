using src.User;
using src.Wall;

namespace SocialNetworkTest.Wall;

public class StubWallDAO : IWallDAO
{
    public List<Brick> GetBricks(User user)
    {
        return new List<Brick>();
    }

    public void AddBrick(User user, Brick brick)
    {
    }
}
