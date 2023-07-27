using src.Exception;
using src.Wall;
using src.Wrapper;
using test.Wrapper;

namespace test.Wall;

public class Tests
{
    private static readonly src.User.User? Guest = null;
    private static readonly src.User.User RegisteredUser = new();

    [Test]
    public void should_Throw_An_Exception_When_User_Is_Not_Logged_In()
    {
        WallService wallService = new WallService(new DummyWallDAO(), new DummyClock());

        Assert.Throws<UserNotLoggedInException>(() =>
            wallService.AnotherBrickInTheWall(new src.User.User(), "", Guest));
    }

    [Test]
    public void should_Throw_An_Exception_When_User_Are_Not_Friend_With()
    {
        WallService wallService = new WallService(new DummyWallDAO(), new DummyClock());

        Assert.Throws<UsersAreNotFriendsException>(() =>
            wallService.AnotherBrickInTheWall(new src.User.User(), "", RegisteredUser));
    }

    [Test]
    public void should_Append_New_Brick_To_Friend_Wall()
    {
        SpyWallDAO spyWallDao = new SpyWallDAO();
        StubClock stubClock = new StubClock();
        WallService wallService = new WallService(spyWallDao, stubClock);
        src.User.User user = new src.User.User();
        user.AddFriend(RegisteredUser);

        wallService.AnotherBrickInTheWall(user, "", RegisteredUser);

        Assert.That(user, Is.EqualTo(spyWallDao.UserParameter));
        Assert.That(new Brick("", stubClock.Now()), Is.EqualTo(spyWallDao.BrickParameter));
    }

    [Test]
    public void appended_Brick_Should_Return_The_Updated_Wall()
    {
        FakeWallDAO fakeWallDao = new FakeWallDAO();
        StubClock stubClock = new StubClock();
        WallService wallService = new WallService(fakeWallDao, stubClock);
        src.User.User user = new src.User.User();
        user.AddFriend(RegisteredUser);

        List<Brick> wall = wallService.AnotherBrickInTheWall(user, "", RegisteredUser);

        Assert.That(wall.Count, Is.EqualTo(1));
        Assert.That(wall[0], Is.EqualTo(new Brick("", stubClock.Now())));
    }
}
