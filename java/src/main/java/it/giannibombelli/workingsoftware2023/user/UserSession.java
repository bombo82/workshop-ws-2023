package it.giannibombelli.workingsoftware2023.user;

import it.giannibombelli.workingsoftware2023.exception.NotTestableCallException;

public class UserSession {
    private static final UserSession userSession = new UserSession();

    private UserSession() {
    }

    public static UserSession getInstance() {
        return userSession;
    }

    public User getLoggedUser() {
        throw new NotTestableCallException("UserSession.getLoggedUser() should not be called in an unit test");
    }
}
