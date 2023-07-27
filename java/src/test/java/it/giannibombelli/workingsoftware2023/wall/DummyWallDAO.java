package it.giannibombelli.workingsoftware2023.wall;

import it.giannibombelli.workingsoftware2023.user.User;

import java.util.List;

public class DummyWallDAO implements WallDAOInterface {

    @Override
    public List<Brick> getBricks(User user) {
        throw new UnsupportedOperationException();
    }

    @Override
    public void addBrick(User user, Brick brick) {
        throw new UnsupportedOperationException();
    }
}
