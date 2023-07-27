package it.giannibombelli.workingsoftware2023.wall;

import it.giannibombelli.workingsoftware2023.user.User;

import java.util.Date;
import java.util.List;

public class SpyWallDAO implements WallDAOInterface {

    private User userParameter;
    private Brick brickParameter;

    User getUserParameter() {
        return userParameter;
    }

    Brick getBrickParameter() {
        return brickParameter;
    }

    @Override
    public List<Brick> getBricks(User user) {
        return List.of(new Brick("", new Date()));
    }

    @Override
    public void addBrick(User user, Brick brick) {
        userParameter = user;
        brickParameter = brick;
    }
}
