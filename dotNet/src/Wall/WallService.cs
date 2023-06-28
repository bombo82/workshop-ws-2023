using src.Exception;
using src.User;

namespace src.Wall;

public class WallService
{
    public List<Brick> AnotherBrickInTheWall(src.User.User user, string message)
    {
        List<Brick> wall = new List<Brick>();
        src.User.User? loggedUser = GetLoggedUser();
        bool isFriend = false;
        if (loggedUser != null)
        {
            foreach (src.User.User friend in user.GetFriends())
            {
                if (friend.Equals(loggedUser))
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

    protected virtual User.User? GetLoggedUser()
    {
        return UserSession.GetInstance().GetLoggedUser();
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
