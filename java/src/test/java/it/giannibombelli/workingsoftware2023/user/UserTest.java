package it.giannibombelli.workingsoftware2023.user;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class UserTest {

    private static final User A_FRIEND = new User();
    private static final User NOT_A_FRIEND = new User();

    @Test
    void shouldInformWhenUserAreNotFriendWith(){
        final User user = new User();
        user.addFriend(A_FRIEND);

        assertFalse(user.isFriendWith(NOT_A_FRIEND));
    }

    @Test
    void shouldInformWhenUserAreFriendWith(){
        final User user = new User();
        user.addFriend(A_FRIEND);

        assertTrue(user.isFriendWith(A_FRIEND));
    }
}
