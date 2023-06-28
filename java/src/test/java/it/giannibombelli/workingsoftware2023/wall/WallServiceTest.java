package it.giannibombelli.workingsoftware2023.wall;

import it.giannibombelli.workingsoftware2023.exception.UserNotLoggedInException;
import it.giannibombelli.workingsoftware2023.exception.UsersAreNotFriendsException;
import it.giannibombelli.workingsoftware2023.user.User;
import it.giannibombelli.workingsoftware2023.wrapper.Clock;
import it.giannibombelli.workingsoftware2023.wrapper.StubClock;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;

class WallServiceTest {
    private static final User GUEST = null;
    private static final User REGISTERED_USER = new User();

    private WallService wallService;
    private Clock clock;

    @BeforeEach
    void setUp() {
        final WallDAOInterface wallDAO = new StubWallDAO();
        clock = new StubClock();
        wallService = new WallService(wallDAO, clock);
    }

    @Test
    void shouldThrowAnExceptionWhenUserIsNotLoggedIn() {
        assertThrows(UserNotLoggedInException.class, () -> wallService.anotherBrickInTheWall(null, "", GUEST));
    }

    @Test
    void shouldThrowAnExceptionWhenUserAreNotFriendWith() {
        assertThrows(UsersAreNotFriendsException.class, () -> wallService.anotherBrickInTheWall(new User(), "", REGISTERED_USER));
    }

    @Test
    void shouldAppendNewBrickToFriendWallAndReturnTheUpdatedWall() {
        final User user = new User();
        user.addFriend(REGISTERED_USER);

        final List<Brick> wall = wallService.anotherBrickInTheWall(user, "", REGISTERED_USER);

        assertEquals(1, wall.size());
    }

    @Test
    void appendedBrickShouldBeTheRightOne() {
        final User user = new User();
        user.addFriend(REGISTERED_USER);

        final List<Brick> wall = wallService.anotherBrickInTheWall(user, "", REGISTERED_USER);

        assertEquals(new Brick("", clock.now()), wall.get(0));
    }
}
