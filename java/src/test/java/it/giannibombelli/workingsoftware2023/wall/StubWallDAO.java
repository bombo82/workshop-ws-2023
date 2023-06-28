package it.giannibombelli.workingsoftware2023.wall;

import it.giannibombelli.workingsoftware2023.user.User;

import java.util.ArrayList;
import java.util.List;

public class StubWallDAO implements WallDAOInterface {
    @Override
    public List<Brick> getBricks(User user) {
        return new ArrayList<>();
    }

    @Override
    public void addBrick(User user, Brick brick) {
    }
}
