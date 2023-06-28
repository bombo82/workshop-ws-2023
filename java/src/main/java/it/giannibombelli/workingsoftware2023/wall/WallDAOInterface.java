package it.giannibombelli.workingsoftware2023.wall;

import it.giannibombelli.workingsoftware2023.user.User;

import java.util.List;

public interface WallDAOInterface {
    List<Brick> getBricks(User user);

    void addBrick(User user, Brick brick);
}
