using src.Exception;
using src.User;
using src.Wall;

namespace SocialNetworkTest.Wall;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void should_Throw_An_Exception_When_User_Is_Not_Logged_In()
    {
        Assert.Throws<UserNotLoggedInException>(() =>
        {
            WallService wallService = new TestableWallService();
            wallService.AnotherBrickInTheWall(new User(), "")
        });
    }

    private class TestableWallService : WallService
    {
        protected override User? GetLoggedUser()
        {
            return null;
        }
    }
}
