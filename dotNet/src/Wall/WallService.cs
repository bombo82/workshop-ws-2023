using SocialNetworkTest.Wall;
using src.Exception;

namespace src.Wall;

public class WallService
{
    private readonly IWallDAO _wallDao;
    private readonly IClock _clock;

    public WallService(IWallDAO wallDao, IClock clock)
    {
        _wallDao = wallDao;
        _clock = clock;
    }

    public List<Brick> AnotherBrickInTheWall(User.User user, string message, User.User? loggedInUser)
    {
        if (loggedInUser == null)
        {
            throw new UserNotLoggedInException();
        }

        if (!user.IsFriendWith(loggedInUser))
        {
            throw new UsersAreNotFriendsException();
        }

        List<Brick> wall = _wallDao.GetBricks(user);
        Brick brick = new Brick(message, _clock.now());
        _wallDao.AddBrick(user, brick);

        wall.Add(brick);
        return wall;
    }
}
