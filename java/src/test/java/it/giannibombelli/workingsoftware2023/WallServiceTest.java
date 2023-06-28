package it.giannibombelli.workingsoftware2023;

import it.giannibombelli.workingsoftware2023.exception.UserNotLoggedInException;
import it.giannibombelli.workingsoftware2023.exception.UsersAreNotFriendsException;
import it.giannibombelli.workingsoftware2023.user.User;
import it.giannibombelli.workingsoftware2023.wall.Brick;
import it.giannibombelli.workingsoftware2023.wall.WallService;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;

class WallServiceTest {
    private static final User GUEST = null;
    private static final User REGISTERED_USER = new User();

    private WallService wallService;

    private User loggedInUser;
    private Date creationDate;

    @BeforeEach
    void setUp() {
        wallService = new TestableWallService();
    }

    @Test
    void shouldThrowAnExceptionWhenUserIsNotLoggedIn() {
        loggedInUser = GUEST;

        assertThrows(UserNotLoggedInException.class, () -> wallService.anotherBrickInTheWall(null, ""));
    }

    @Test
    void shouldThrowAnExceptionWhenUserAreNotFriendWith() {
        loggedInUser = REGISTERED_USER;

        assertThrows(UsersAreNotFriendsException.class, () -> wallService.anotherBrickInTheWall(new User(), ""));
    }

    @Test
    void shouldAppendNewBrickToFriendWallAndReturnTheUpdatedWall() {
        loggedInUser = REGISTERED_USER;
        final User user = new User();
        user.addFriend(REGISTERED_USER);

        final List<Brick> wall = wallService.anotherBrickInTheWall(user, "");

        assertEquals(1, wall.size());
    }

    @Test
    void appendedBrickShouldBeTheRightOne() {
        loggedInUser = REGISTERED_USER;
        creationDate = new Date();
        final User user = new User();
        user.addFriend(REGISTERED_USER);

        final List<Brick> wall = wallService.anotherBrickInTheWall(user, "");

        assertEquals(new Brick("", creationDate), wall.get(0));
    }

    private class TestableWallService extends WallService {
        @Override
        protected User getLoggedUser() {
            return loggedInUser;
        }

        @Override
        protected List<Brick> findBricksByUser(User user) {
            return new ArrayList<>();
        }

        @Override
        protected void addBrickToUser(User user, Brick brick) {
        }

        @Override
        protected Date getCreationDate() {
            return creationDate;
        }
    }
}
