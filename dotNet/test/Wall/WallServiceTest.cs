using src.Exception;
using src.User;
using src.Wall;

namespace SocialNetworkTest.Wall;

public class Tests
{
    private static readonly User? Guest = null;
    private static readonly User RegisteredUser = new User();

    private WallService _wallService;

    private static User? _loggedInUser;

    [SetUp]
    public void Setup()
    {
        _wallService = new TestableWallService();
    }

    [Test]
    public void should_Throw_An_Exception_When_User_Is_Not_Logged_In()
    {
        _loggedInUser = Guest;

        Assert.Throws<UserNotLoggedInException>(() => _wallService.AnotherBrickInTheWall(new User(), ""));
    }

    [Test]
    public void should_Throw_An_Exception_When_User_Are_Not_Friend_With()
    {
        _loggedInUser = RegisteredUser;

        Assert.Throws<UsersAreNotFriendsException>(() => _wallService.AnotherBrickInTheWall(new User(), ""));
    }

    [Test]
    public void should_Append_New_Brick_To_Friend_Wall_And_Return_The_Updated_Wall()
    {
        _loggedInUser = RegisteredUser;
        User user = new User();
        user.AddFriend(RegisteredUser);

        List<Brick> wall = _wallService.AnotherBrickInTheWall(user, "");

        Assert.That(wall.Count, Is.EqualTo(1));
    }

    private class TestableWallService : WallService
    {
        protected override User? GetLoggedUser()
        {
            return _loggedInUser;
        }

        protected override List<Brick> FindBricksByUser(User user)
        {
            return new List<Brick>();
        }

        protected override void AddBrickToUser(User user, Brick brick)
        {
        }
    }
}
