using System.Collections.Immutable;
using src.Exception;
using src.Wrapper;

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

        Brick brick = new Brick(message, _clock.Now());
        _wallDao.AddBrick(user, brick);

        return _wallDao.GetBricks(user).ToList();
    }
}
