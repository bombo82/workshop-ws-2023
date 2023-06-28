
namespace test.User;

public class UserTest
{
    private static readonly src.User.User? A_FRIEND = new();
    private static readonly src.User.User? NOT_A_FRIEND = new();

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void should_Inform_When_User_Are_Not_Friend_With()
    {
        src.User.User user = new src.User.User();
        user.AddFriend(A_FRIEND);

        Assert.That(user.IsFriendWith(NOT_A_FRIEND), Is.False);
    }

    [Test]
    public void should_Inform_When_User_Are_Friend_With()
    {
        src.User.User user = new();
        user.AddFriend(A_FRIEND);

        Assert.That(user.IsFriendWith(A_FRIEND), Is.True);
    }
}
