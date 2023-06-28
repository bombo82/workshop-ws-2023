namespace src.User;

public class User
{
    private readonly List<User> friends = new();

    public List<User> GetFriends()
    {
        return friends;
    }

    public void AddFriend(User user)
    {
        friends.Add(user);
    }

    public bool IsFriendWith(User anotherUser)
    {
        return friends.Contains(anotherUser);
    }
}
