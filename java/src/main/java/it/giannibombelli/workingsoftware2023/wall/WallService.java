package it.giannibombelli.workingsoftware2023.wall;

import it.giannibombelli.workingsoftware2023.exception.UserNotLoggedInException;
import it.giannibombelli.workingsoftware2023.exception.UsersAreNotFriendsException;
import it.giannibombelli.workingsoftware2023.user.User;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class WallService {

    private final WallDAOInterface wallDAO;

    public WallService(WallDAOInterface wallDAO) {
        this.wallDAO = wallDAO;
    }

    public List<Brick> anotherBrickInTheWall(User user, String message, User loggedInUser) throws UserNotLoggedInException {
        List<Brick> wall = new ArrayList<>();
        boolean isFriend = false;
        if (loggedInUser != null) {
            for (User friend : user.getFriends()) {
                if (friend.equals(loggedInUser)) {
                    isFriend = true;
                    break;
                }
            }
            if (isFriend) {
                wall = wallDAO.getBricks(user);
                Brick brick = new Brick(message, getCreationDate());
                wallDAO.addBrick(user, brick);

                wall.add(brick);
                return wall;
            }
            throw new UsersAreNotFriendsException();
        } else {
            throw new UserNotLoggedInException();
        }
    }

    protected Date getCreationDate() {
        return new Date();
    }

}
