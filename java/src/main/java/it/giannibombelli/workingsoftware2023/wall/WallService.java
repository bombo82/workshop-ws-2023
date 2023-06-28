package it.giannibombelli.workingsoftware2023.wall;

import it.giannibombelli.workingsoftware2023.exception.UserNotLoggedInException;
import it.giannibombelli.workingsoftware2023.exception.UsersAreNotFriendsException;
import it.giannibombelli.workingsoftware2023.user.User;
import it.giannibombelli.workingsoftware2023.wrapper.Clock;

import java.util.List;

public class WallService {

    private final WallDAOInterface wallDAO;
    private final Clock clock;

    public WallService(WallDAOInterface wallDAO, Clock clock) {
        this.wallDAO = wallDAO;
        this.clock = clock;
    }

    public List<Brick> anotherBrickInTheWall(User user, String message, User loggedInUser) {
        if (loggedInUser != null) {
            boolean isFriend = false;
            for (User friend : user.getFriends()) {
                if (friend.equals(loggedInUser)) {
                    isFriend = true;
                    break;
                }
            }
            if (isFriend) {
                List<Brick> wall = wallDAO.getBricks(user);
                Brick brick = new Brick(message, clock.now());
                wallDAO.addBrick(user, brick);

                wall.add(brick);
                return wall;
            }
            throw new UsersAreNotFriendsException();
        } else {
            throw new UserNotLoggedInException();
        }
    }

}
