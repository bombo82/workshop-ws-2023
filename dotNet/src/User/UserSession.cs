using src.Exception;

namespace src.User;

public class UserSession
{
    private static readonly UserSession userSession = new UserSession();

    private UserSession()
    {
    }

    public static UserSession GetInstance()
    {
        return userSession;
    }

    public src.User.User? GetLoggedUser()
    {
        throw new NotTestableCallException("UserSession.GetLoggedUser() should not be called in an unit test");
    }
}
