using src.Exception;

namespace src.Wall;

public class WallService
{
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
                wall = FindBricksByUser(user);
                Brick brick = new Brick(message, CreationDate());
                AddBrickToUser(user, brick);

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

    protected virtual List<Brick> FindBricksByUser(User.User user)
    {
        return WallDAO.FindBricksByUser(user);
    }

    protected virtual void AddBrickToUser(User.User user, Brick brick)
    {
        WallDAO.AddBrickToUser(user, brick);
    }

    protected virtual DateTime CreationDate()
    {
        return DateTime.Now;
    }
}
