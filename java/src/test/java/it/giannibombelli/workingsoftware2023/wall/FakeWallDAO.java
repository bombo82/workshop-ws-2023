package it.giannibombelli.workingsoftware2023.wall;

import it.giannibombelli.workingsoftware2023.user.User;

import java.util.ArrayList;
import java.util.List;

public class FakeWallDAO implements WallDAOInterface {
    final ArrayList<Brick> wall = new ArrayList<>();

    @Override
    public List<Brick> getBricks(User user) {
        return List.copyOf(wall);
    }

    @Override
    public void addBrick(User user, Brick brick) {
        wall.add(brick);
    }
}
