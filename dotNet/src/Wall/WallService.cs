using SocialNetworkTest.Wall;
using src.Exception;

namespace src.Wall;

public class WallService
{
    private readonly IWallDAO _wallDao;

    protected WallService(IWallDAO wallDao)
    {
        _wallDao = wallDao;
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
                Brick brick = new Brick(message, CreationDate());
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

    protected virtual DateTime CreationDate()
    {
        return DateTime.Now;
    }
}
