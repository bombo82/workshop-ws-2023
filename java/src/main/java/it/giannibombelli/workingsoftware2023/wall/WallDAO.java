package it.giannibombelli.workingsoftware2023.wall;

import it.giannibombelli.workingsoftware2023.exception.NotTestableCallException;
import it.giannibombelli.workingsoftware2023.user.User;

import java.util.List;

public class WallDAO {
    public static List<Brick> findBricksByUser(User user) {
        throw new NotTestableCallException("WallDAO should not be invoked on an unit test.");
    }

    public static void addBrickToUser(User user, Brick brick) {
        throw new NotTestableCallException("WallDAO should not be invoked on an unit test.");
    }
}
