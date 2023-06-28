package it.giannibombelli.workingsoftware2023;

import it.giannibombelli.workingsoftware2023.user.User;
import it.giannibombelli.workingsoftware2023.wall.Brick;
import it.giannibombelli.workingsoftware2023.wall.WallDAOInterface;

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
