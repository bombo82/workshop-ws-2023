package it.giannibombelli.workingsoftware2023;

import it.giannibombelli.workingsoftware2023.exception.UserNotLoggedInException;
import it.giannibombelli.workingsoftware2023.user.User;
import it.giannibombelli.workingsoftware2023.wall.WallService;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertThrows;

class WallServiceTest {
    @Test
    void shouldThrowAnExceptionWhenUserIsNotLoggedIn() {
        assertThrows(UserNotLoggedInException.class, () -> {
            final WallService wallService = new TestableWallService();
            wallService.anotherBrickInTheWall(null, "");
        });
    }

    private class TestableWallService extends WallService {
        @Override
        protected User getLoggedUser() {
            return null;
        }
    }
}
