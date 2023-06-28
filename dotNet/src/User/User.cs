namespace src.User;

public class User
{
    private readonly List<User> _friends = new();

    public List<User> GetFriends()
    {
        return _friends;
    }

    public void AddFriend(User user)
    {
        _friends.Add(user);
    }

    public bool IsFriendWith(User anotherUser)
    {
        return _friends.Contains(anotherUser);
    }
}
