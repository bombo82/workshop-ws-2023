using src.Wall;

namespace test.Wall;

public class StubWallDAO : IWallDAO
{
    public List<Brick> GetBricks(src.User.User user)
    {
        return new List<Brick>();
    }

    public void AddBrick(src.User.User user, Brick brick)
    {
    }
}
