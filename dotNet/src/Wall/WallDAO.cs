using src.Exception;

namespace src.Wall;

public class WallDAO
{
    public static List<Brick> FindBricksByUser(src.User.User user)
    {
        throw new NotTestableCallException("WallDAO should not be invoked on an unit test.");
    }

    public static void AddBrickToUser(src.User.User user, Brick brick)
    {
        throw new NotTestableCallException("WallDAO should not be invoked on an unit test.");
    }
}
