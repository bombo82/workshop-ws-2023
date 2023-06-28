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
        List<Brick> wall = new List<Brick>();
        bool isFriend = false;
        if (loggedInUser != null)
        {
            foreach (src.User.User friend in user.GetFriends())
            {
                if (friend.Equals(loggedInUser))
                {
                    isFriend = true;
                    break;
                }
            }

            if (isFriend)
            {
                wall = _wallDao.GetBricks(user);
                Brick brick = new Brick(message, _clock.now());
                _wallDao.AddBrick(user, brick);

                wall.Add(brick);
                return wall;
            }

            throw new UsersAreNotFriendsException();
        }
        else
        {
            throw new UserNotLoggedInException();
        }
    }
}