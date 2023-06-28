package it.giannibombelli.workingsoftware2023.wall;

import it.giannibombelli.workingsoftware2023.exception.NotTestableCallException;
import it.giannibombelli.workingsoftware2023.user.User;

import java.util.List;

public class WallDAO implements WallDAOInterface {
    @Deprecated
    public static List<Brick> findBricksByUser(User user) {
        throw new NotTestableCallException("WallDAO should not be invoked on an unit test.");
    }

    @Deprecated
    public static void addBrickToUser(User user, Brick brick) {
        throw new NotTestableCallException("WallDAO should not be invoked on an unit test.");
    }

    @Override
    public List<Brick> getBricks(User user) {
        return findBricksByUser(user);
    }

    @Override
    public void addBrick(User user, Brick brick) {
        addBrickToUser(user, brick);
    }
}
