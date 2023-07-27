package it.giannibombelli.workingsoftware2023.wall;

import it.giannibombelli.workingsoftware2023.exception.UserNotLoggedInException;
import it.giannibombelli.workingsoftware2023.exception.UsersAreNotFriendsException;
import it.giannibombelli.workingsoftware2023.user.User;
import it.giannibombelli.workingsoftware2023.wrapper.DummyClock;
import it.giannibombelli.workingsoftware2023.wrapper.StubClock;
import org.junit.jupiter.api.Test;

import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;

class WallServiceTest {
    private static final User GUEST = null;
    private static final User REGISTERED_USER = new User();

    @Test
    void shouldThrowAnExceptionWhenUserIsNotLoggedIn() {
        final WallService wallService = new WallService(new DummyWallDAO(), new DummyClock());

        assertThrows(UserNotLoggedInException.class, () ->
                wallService.anotherBrickInTheWall(null, "", GUEST)
        );
    }

    @Test
    void shouldThrowAnExceptionWhenUserAreNotFriendWith() {
        final WallService wallService = new WallService(new DummyWallDAO(), new DummyClock());

        assertThrows(UsersAreNotFriendsException.class, () ->
                wallService.anotherBrickInTheWall(new User(), "", REGISTERED_USER)
        );
    }

    @Test
    void shouldAppendNewBrickToFriendWall() {
        final SpyWallDAO spyWallDAO = new SpyWallDAO();
        final StubClock stubClock = new StubClock();
        final WallService wallService = new WallService(spyWallDAO, stubClock);
        final User user = new User();
        user.addFriend(REGISTERED_USER);

        wallService.anotherBrickInTheWall(user, "", REGISTERED_USER);

        assertEquals(user, spyWallDAO.getUserParameter());
        assertEquals(new Brick("", stubClock.now()), spyWallDAO.getBrickParameter());
    }

    @Test
    void appendedBrickShouldReturnTheUpdatedWall() {
        final StubClock stubClock = new StubClock();
        final WallService wallService = new WallService(new FakeWallDAO(), stubClock);
        final User user = new User();
        user.addFriend(REGISTERED_USER);

        final List<Brick> wall = wallService.anotherBrickInTheWall(user, "", REGISTERED_USER);

        assertEquals(1, wall.size());
        assertEquals(new Brick("", stubClock.now()), wall.get(0));
    }
}
