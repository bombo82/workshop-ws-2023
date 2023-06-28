namespace src.User;

public class User
{
    private readonly List<User> friends = new List<User>();

    public List<User> GetFriends()
    {
        return friends;
    }

    public void AddFriend(User user)
    {
        friends.Add(user);
    }
}
