using src.Exception;
using src.User;
using src.Wall;

namespace SocialNetworkTest.Wall;

public class Tests
{
    private static readonly User? Guest = null;
    private static readonly User RegisteredUser = new User();

    private WallService _wallService;

    private static DateTime _creationDate;

    [SetUp]
    public void Setup()
    {
        IWallDAO wallDao = new StubWallDAO();
        _wallService = new TestableWallService(wallDao);
    }

    [Test]
    public void should_Throw_An_Exception_When_User_Is_Not_Logged_In()
    {
        Assert.Throws<UserNotLoggedInException>(() => _wallService.AnotherBrickInTheWall(new User(), "", Guest));
    }

    [Test]
    public void should_Throw_An_Exception_When_User_Are_Not_Friend_With()
    {
        Assert.Throws<UsersAreNotFriendsException>(() =>
            _wallService.AnotherBrickInTheWall(new User(), "", RegisteredUser));
    }

    [Test]
    public void should_Append_New_Brick_To_Friend_Wall_And_Return_The_Updated_Wall()
    {
        User user = new User();
        user.AddFriend(RegisteredUser);

        List<Brick> wall = _wallService.AnotherBrickInTheWall(user, "", RegisteredUser);

        Assert.That(wall.Count, Is.EqualTo(1));
    }

    [Test]
    public void appended_Brick_Should_Be_The_Right_One()
    {
        _creationDate = DateTime.Now;
        User user = new User();
        user.AddFriend(RegisteredUser);

        List<Brick> wall = _wallService.AnotherBrickInTheWall(user, "", RegisteredUser);

        Assert.That(wall[0], Is.EqualTo(new Brick("", _creationDate)));
    }

    private class TestableWallService : WallService
    {
        public TestableWallService(IWallDAO wallDao) : base(wallDao)
        {
        }

        protected override DateTime CreationDate()
        {
            return _creationDate;
        }
    }
}
