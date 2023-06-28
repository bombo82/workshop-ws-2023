package it.giannibombelli.workingsoftware2023.wall;

import it.giannibombelli.workingsoftware2023.exception.UserNotLoggedInException;
import it.giannibombelli.workingsoftware2023.exception.UsersAreNotFriendsException;
import it.giannibombelli.workingsoftware2023.user.User;
import it.giannibombelli.workingsoftware2023.user.UserSession;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class WallService {

    public List<Brick> anotherBrickInTheWall(User user, String message) throws UserNotLoggedInException {
        List<Brick> wall = new ArrayList<>();
        User loggedUser = UserSession.getInstance().getLoggedUser();
        boolean isFriend = false;
        if (loggedUser != null) {
            for (User friend : user.getFriends()) {
                if (friend.equals(loggedUser)) {
                    isFriend = true;
                    break;
                }
            }
            if (isFriend) {
                wall = WallDAO.findBricksByUser(user);
                Brick brick = new Brick(message, new Date());
                WallDAO.addBrickToUser(user, brick);

                wall.add(brick);
                return wall;
            }
            throw new UsersAreNotFriendsException();
        } else {
            throw new UserNotLoggedInException();
        }
    }

}
